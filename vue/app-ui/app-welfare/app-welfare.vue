<!--
 * @Name: 福利待遇组建
 * @Author: bpwen.cn
 * @Date: 2021-11-04 11:31:55
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-27 21:20:58

	<u-form-item label="福利待遇" :label-position="form.top" :label-width="form.labelWidth" prop="daiyu" :required="form.required">
        <u-input type="select" v-model="formData.daiyu" @click="bool.daiyu = true" placeholder="请选择福利待遇" :select-open="bool.daiyu" :border="form.border"></u-input>
    </u-form-item>

    <app-welfare id="31" title="选择福利待遇" :show.sync="bool.daiyu" v-model="formData.daiyu"></app-welfare>

	daiyu: false
-->

<template>
	<hqs-popup class="popup" :title="title" from="bottom" :height="height" @back="onBack" v-model="bool" v-if="welfare.length != 0">
		<view class="p-20-t">
			<axb-checkbox :list="welfare" :multi="true" @change="radioChangeType"></axb-checkbox>
		</view>
	</hqs-popup>
</template>

<script>
	import { List } from '@/api/custom/attribute'
	
	export default {
		props:{
            title:{
                type:String,
                default: ''
            },
			show:{
				type: Boolean,
				default: function() {
					return false;
				}
			},
			// 弹窗内容高度(当from=top或bottom时起作用)
			height: {
				type: String,
				default: '',
			},
            // 自定义属性对应的ID
			id:{
				type: [String, Number],
				default: ''
			},
			value: {
				type: String,
				default: ''
			}
		},
		data() {
			return {
				bool: false,
				welfare:[],
				_welfare:[],
				formData:{
					welfare:[]
				}
			}
		},
		watch:{
			show(v){
				if(v){
					this.bool = v;
					if(this.welfare.length == 0){
						this.onList();
					}else{
						if(this.value != ""){
							this.onVal();
						}
					}
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
			onList(){
				List({id: this.id}).then((response) => {
					this.welfare = response.data.map((item) => {
						return {
							value: item.id,
							name: item.name,
							checked: 0
						}
					})
					if(this.value != ""){
						this.onVal();
					}
				}).catch(() => {
					this.welfare = [];
				});
			},
			onBack() {
				if(this._welfare.length != 0){
					this.formData.welfare = '';
					this._welfare.forEach((key) => {
						this.welfare.forEach((keya) => {
							if(keya.value == key ){
								this.formData.welfare += this.formData.welfare == '' ? keya.name :  ',' + keya.name;
							}
						})
					})
                    this.$emit("input", this.formData.welfare)
				}
                this.bool = false;
			},
			radioChangeType(val){
				this._welfare = val;
			},
			onVal(){
				let Arr = this.value.split(',')
				this.welfare.forEach((keya, index) => {
					keya.checked = 0;
					Arr.forEach((key) => {
						if(keya.name == key){
							keya.checked = 1;
						}
					})
				})
			}
		}
	}
</script>