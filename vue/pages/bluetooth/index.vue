<!--
 * @Name: 蓝牙设备
 * @Author: bpwen.cn
 * @Date: 2021-12-06 17:22:29
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-08 16:59:57
-->
<template>
    <view class="mail p-20">
        <view class="flex-cen">
            <u-button type="primary" class="m" v-if="!search" @click="onopenBluetoothAdapter">搜索设备</u-button>
            <u-button type="error" class="m" v-else @click="onstopBluetoothDevicesDiscovery">停止搜索</u-button>
            <u-button type="primary" class="m m-15-l" @click="ongetBluetoothAdapterState">获取蓝牙设备的信号强度</u-button>
        </view>
        <view class="m-20" v-if="search">
            <u-loadmore :status="loadmore.status" :icon-type="loadmore.iconType" :load-text="loadmore.loadText" />
        </view>
        <view class="m-20-t" v-if="list.length != 0">
            <view v-for="(item, index) in list" :key="index" class="m-15-tb p-15-b hx" @click="onOpen(item)">
                <view class="h-25-l">名称：{{ item.name }} </view>
                <view class="h-25-l">信号强度：{{ item.RSSI }}</view>
                <view class="h-25-l">设备的id：{{ item.deviceId }}</view>
            </view>
            
        </view>
    </view>
</template>

<script>
    export default {
        data () {
            return {
				search: false,
                loadmore:{
                    status: 'loading',
                    loadText: {
                        loading: '设备搜索中'
                    },
                },
                ab2hex:buffer => {
                    const hexArr = Array.prototype.map.call(
                        new Uint8Array(buffer),
                        function (bit) {
                        return ('00' + bit.toString(16)).slice(-2)
                        }
                    )
                    return hexArr.join('')
                },
                state:{
                    item:[],
                    connect: false
                },
                list:[]
            }
        },
        watch: {
            
        },
        computed: {
            
        },
        created () {
            
        },
        mounted () {
            
        },
        methods: {
            onfail(res){
                var text = ''
                switch(res.code)
                {
                    case 10001:
                        text = '请打开蓝牙'
                        break;
                    default:
                        text = '未知错误错误编码：'+ res.cade
                        break;
                }
                console.log(res)

                uni.showLoading({
                    icon: 'none',
                    title: text,
                    success:function(){
                        setTimeout(function () {
                            uni.hideLoading();
                        }, 1000);
                    }
                });
            },
            //初始化蓝牙模块
            onopenBluetoothAdapter(){
				this.search = true;
                let _this = this;
                this.list = []
                uni.openBluetoothAdapter({
                    success(res) {
                        _this.onstartBluetoothDevicesDiscovery();
                    },
                    fail(res){
                        _this.onfail(res);
                    }
                })
            },
            //开始搜寻附近的蓝牙外围设备
            onstartBluetoothDevicesDiscovery(){
                let _this = this;
                uni.startBluetoothDevicesDiscovery({
                    success(res) {
                        console.log(res)
                        _this.ononBluetoothDeviceFound();
                    },
                    fail(res){
                        _this.onfail(res);
                    }
                })
            },
            //监听寻找到新设备的事件
            ononBluetoothDeviceFound(){
                let _this = this;

                uni.onBluetoothDeviceFound(function (devices) {
                    let str = devices.devices[0];
                    if(str.name != ''){
                        let bool = true
                        _this.list.filter(function (item) {
                            if(item.deviceId == str.deviceId){
                                bool = false
                            }
                        })
                        if(bool){
                        _this.list.push(devices.devices[0]);
                        }
                    }
                    //console.log(_this.ab2hex(devices[0].advertisData))
                })
            },
            //停止搜寻附近的蓝牙外围设备
            onstopBluetoothDevicesDiscovery(){
                let _this = this;
                uni.stopBluetoothDevicesDiscovery({
                    success(res) {
						_this.search = false;
                        console.log('停止搜寻',res);
                        //_this.ongetBluetoothDevices();
                    }
                })
            },
            //获取在蓝牙模块生效期间所有已发现的蓝牙设备
            ongetBluetoothDevices(){
                let _this = this;
                uni.getBluetoothDevices({
                    success(res) {
                        //console.log(res.devices.length)
                        // if (res.devices[0]) {
                        //     _this.list = _this.ab2hex(res.devices[0].advertisData);
                        //     //console.log(_this.ab2hex(res.devices[0].advertisData))
                        // }
                        //_this.list.push(devices);
                    }
                })
            },
            //连接低功耗蓝牙设备
            onOpen(item){
                let _this = this;
                uni.showModal({
                    title: '提示',
                    content: '是否连接该蓝牙设备\n\n'+ item.name,
                    success: res => {
                        if (res.confirm) {
                            _this.state.item = [];
                            _this.state.item.push(item)
                            uni.createBLEConnection({
                                deviceId: item.deviceId,
                                success(res) {
                                    _this.state.connect = true;
									_this.onstopBluetoothDevicesDiscovery()
                                },
                                fail(res){
                                    _this.onfail(res);
                                }
                            })
                        }
                    }
                });
            },
			//获取蓝牙设备的信号强度
			ongetBluetoothAdapterState(){
				if(this.state.item.length != 0){
					let _this = this;
					uni.getBLEDeviceRSSI({
						deviceId: _this.state.item[0].deviceId,
						success(res) {
							console.log(res)
						},
						fail(res){
							_this.onfail(res);
						}
					})
				}
			}
        },
        destroyed () {
            
        },
    };
</script>

<style lang="less" scoped>

</style>