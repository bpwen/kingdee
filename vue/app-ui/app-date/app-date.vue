<!--
 * @Name: 自定义属性 Picker 选择器 组件
 * @Author: bpwen.cn
 * @Date: 2021-11-05 10:54:55
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-27 20:31:25
 * @url: https://v1.uviewui.com/components/picker.html
 * @return <app-date v-model="formData.zzksdate" :show.sync="bool.zzksdate" format="yyyy-MM"></app-date>
-->

<template>
    <u-picker mode="time" v-model="bool" :params="params" :default-time="value" @confirm="onBack"></u-picker>
</template>

<script>
	export default {
		name:'app-date',
        props:{
			// select 是否显示
			show:{
				type: Boolean,
				default: false
			},
			// 指定内容
			value: {
				type: [String, Number],
				default: ''
			},
            // 返回格式
			format:{
				type: String,
				default: 'yyyy-MM-dd HH:mm:ss'
			}
		},
		data() {
			return {
				bool: false,
                params:{},
                Arr:[
                    { name : 'yyyy', val: 'year'},
                    { name : 'MM', val: 'month'},
                    { name : 'dd', val: 'day'},
                    { name : 'HH', val: 'hour'},
                    { name : 'mm', val: 'minute'},
                    { name : 'ss', val: 'second'}
                ]
			}
		},
		watch:{
            format: {
                immediate: true,
                handler: function (v) {
                    this.Arr.forEach((item) => {
                        if(v.includes(item.name)){ this.params[item.val] = true }
                    })
                }
            },
			show(v){
                if(v){
                    this.bool = v;
                }
			},
			//点击遮罩关闭回调null判断关闭窗口
			bool(v){
				if(!v){
                    this.$emit('update:show', false)
                }
			}
		},
		methods: {
			onBack(e) {
                let label = this.format;
                this.Arr.forEach((item) => {
                    if(label.includes(item.name)){ label = label.replace(item.name, e[item.val]) }
                })
				this.bool = false;
                this.$emit("input", label)
			}
		}
	}
</script>