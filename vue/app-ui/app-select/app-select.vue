<!--
 * @Name: 自定义属性 select 组件
 * @Author: bpwen.cn
 * @Date: 2021-11-05 10:54:55
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-28 00:57:52

    文本
    <u-input type="text" v-model="formData.zzjsdate" placeholder="结束时间" :border="form.border" input-align="center" disabled @click="bool.zzksdate = true"></u-input>
    <app-date v-model="formData.zzjsdate" :show.sync="bool.zzjsdate" format="yyyy-MM"></app-date>

	请求某个属性
	<u-input type="select" v-model="formData.nature" @click="bool.nature = true" placeholder="请选择企业性质" :select-open="bool.scale" :border="form.border"></u-input>
	<app-select id="60" v-model="formData.nature" :show.sync="bool.nature"></app-select>
	 
	传参数
	<u-input type="select" v-model="formData.region" @click="bool.region = true" placeholder="请选择所在地区" :select-open="bool.region" :border="form.border"></u-input>
	<app-select mode="mutil-column-auto" :options="options" :showCount="2" name="region" v-model="formData.region" :show.sync="bool.region"></app-select>

    /*==固定===========================================================================

        性别
            <u-form-item label="性别" :label-position="form.top" :label-width="form.labelWidth" prop="sex" :required="form.required">
                <u-input type="select" v-model="formData.sex" @click="bool.sex = true" placeholder="请选择" :select-open="bool.sex" :border="form.border"></u-input>
                <app-select name="sex" type="sex" v-model="formData.sex" :show.sync="bool.sex"></app-select>
            </u-form-item>

        归属地
            <u-form-item label="所在地区" :label-position="form.top" :label-width="form.labelWidth" prop="region" :required="form.required">
                <u-input type="select" v-model="formData.region" @click="bool.region = true" placeholder="请选择所在地区" :select-open="bool.region" :border="form.border"></u-input>
                <app-select mode="mutil-column-auto" :options="options" name="region" v-model="formData.region" :show.sync="bool.region"></app-select>
            </u-form-item>
            import { citys } from '@/util/citys'
            
            mounted() {
                this.onCitys();
            },
            methods: {
                //获取归属地
                onCitys(){
                    citys().then(res => {
                        this.options = res;
                    })
                }
            }
-->

<template>
	<bpw-select
	v-if="list.length != 0"
	:mode="mode"
	v-model="bool"
	:list="list"
	:default-value="page"
	:show-count="showCount"
	@confirm="onBack"></bpw-select>
</template>

<script>
	import { List } from '@/api/custom/attribute'
	export default {
		name:'app-select',
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
			// 自定义属性对应的ID
			id:{
				type: [String, Number],
				default: ''
			},
			// 文本字段名称
			name:{
				type: [String, Number],
				default: ''
			},
			// 模式选择，single-column-单列，mutil-column-多列，mutil-column-auto-多列联动
			mode: {
				type: String,
				default: 'single-column'
			},
			// 传数据接收
			options:{
                type:[Object, Array],
                default: ()=>[]
            },
			// mutil-column-auto-多列联动 显示几列
			showCount:{
				type: [String, Number],
				default: 0
			},
			//mutil-column-auto-多列联动 传的字符用什么标识转换为数组
			split:{
				type: String,
				default: '-'
			},
            //选择类型对应 data 里面的 optionsType，如传 sex
            type:{
                type:String,
                default: ''
            }
		},
		data() {
			return {
				bool: false,
				page:[],
				list:[],
                optionsType:{
                    // sex:[
                    //     {value: 1, label: '男'},
                    //     {value: 0, label: '女'}
                    // ]
                }
			}
		},
		watch:{
			show(v){
				if(v){
					this.bool = v;
					if(this.list.length == 0){
						this.onList();
					}else{
						this.onVal();
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
				if(this.id != ""){
					List({id: this.id}).then((response) => {
						this.list = response.data.map((item) => {
							return {
								value: item.id,
								label: item.name
							}
						})
						this.onVal();
					}).catch(() => {
						this.list = [];
					});
				}else{
					if(this.options.length != 0){
						this.list = this.options;
						this.onVal();
					}else{
                        if(this.type != ''){
                            this.list = this.optionsType[this.type];
                            this.onVal();
                        }
                    }
				}
			},
			onBack(e) {
				let label = ''
				e.map((val, index) => {
					label += label == '' ? val.label : '-' + val.label;
				})
				this.bool = false;
                this.$emit("input", label)
			},
			// 修改查看有值的时候让列表对应相关数据
			onVal(){
				if(this.value != ""){
					if(this.mode == "single-column"){
						this.list.filter((v, i) => {
							if(this.value == v.label){
								this.page = [i]
							}
						})
					}else{
						this.page = [];
						const Data = this.value.split(this.split);
						if(Data.length != 0){
							this.list.filter((v, i) => {
								if(Data[this.page.length] == v.label){
									this.page.push(i)
									if(v.children){
										this.onForVal(v.children, Data);
									}
								}
							})
						}
					}
				}
			},
			// 用于多状态查询 children 下相关对应的数据
			onForVal(children, Data){
				children.filter((v, i) => {
					if(Data[this.page.length] == v.label){
						this.page.push(i)
						if(v.children){
							this.onForVal(v.children, Data);
						}
					}
				})
			}
		}
	}
</script>