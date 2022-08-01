<!--
* @Name: 首页
* @Author: bpwen.cn
* @Date: 2021-12-03 09:09:54
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-13 18:39:17
-->
<template>
    <view class="mail">
        <u-grid :col="3">
            <u-grid-item v-for="(item, index) in list.grid" :key="index" @click="onGrid(item)">
                <u-icon :name="item.icon" :size="46" class="m-20-b"></u-icon>
                <view class="grid-text">{{ item.name }}</view>
            </u-grid-item>
        </u-grid>
        <view class="p-50">
            库存：{{count.data}}
        </view>
    </view>
</template>

<script>
    import { count } from '@/api/stock/stock'

    export default {
        data () {
            return {
                list:{
                    grid:[
                        { name:'收款', icon:'red-packet' },
                        { name:'销售订单', icon:'order' },
                        { name:'客户', icon:'account-fill', href:'pages/customer/index' },
                        { name:'蓝牙', icon:'account-fill', href:'pages/bluetooth/index' },
                        { name:'销售出库但', icon:'account-fill', href:'pages/outboundOrder/index' }
                    ]
                },
                count:0
            }
        },
        mounted(){
            count({
                fmaterialid: 100429,
                //fstockid: 130093
            }).then((res) => {
                this.count = res;
            });
        },
        methods: {
            onGrid(row){
                if(row.href === undefined){
                    uni.showLoading({
                        icon: 'none',
                        title: '功能开发中,请耐心等待',
                        success:function(){
                            setTimeout(function () {
                                uni.hideLoading();
                            }, 2000);
                        }
                    });
                }else{
                    uni.navigateTo({
                        url: row.href
                    });
                }
            }
        }
    };
</script>

<style lang="less" scoped>

</style>