<!--
 * @Name: ActionSheet 操作菜单
 * @Author: bpwen.cn
 * @Date: 2021-11-27 23:57:54
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-28 05:01:06
 * @url: https://v1.uviewui.com/components/actionSheet.html

    固定
        <app-action-sheet title="性别选择" type="sex" v-model="formData.sex" :show.sync="bool.sex"></app-action-sheet>

    传值
        <app-action-sheet title="工作类型" :list="options.leixin" v-model="formData.leixin" :show.sync="bool.leixin"></app-action-sheet>

        options:{
            leixin:[
                {text: '全职'},
                {text: '兼职'},
                {text: '实习'}
            ]
        }
-->
<template>
    <u-action-sheet :list="params" v-model="bool" :tips="tips" @click="onClick"></u-action-sheet>
</template>

<script>
    export default {
        name:'app-action-sheet',
        props:{
            show:{
                type:Boolean,
                default: false
            },
            list:{
                type:Array,
                default: ()=>[]
            },
            type:{
                type:String,
                default: ''
            },
            title:{
               type:String,
               default: ''
            }
        },
		data() {
			return {
				bool: false,
                params:{},
                tips: {
					text: this.title,
				},
                options:{
                    //性别
                    sex:[
                        {text: '男'},
                        {text: '女'}
                    ],
                    //工作类型
                    leixin:[
                        {text: '全职'},
                        {text: '兼职'},
                        {text: '实习'}
                    ],
                    //求职状态
                    jobstatus:[
                        {text: '目前正在找工作'},
                        {text: '观望有好的机会会考虑'},
                        {text: '我目前不想换工作'}
                    ],
                    //到岗时间
                    arrivaltime:[
                        {text: '随时'},
                        {text: '１周内'},
                        {text: '１个月内'},
                        {text: '３个月内'},
                        {text: '待定'}
                    ],
                }
			}
		},
		watch:{
            list: {
                immediate: true,
                handler: function (v) {
                    if(v.length != ''){
                        this.params = v
                    }else{
                        this.params = this.options[this.type]
                    }
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
			onClick(index) {
				this.bool = false;
                this.$emit("input", this.params[index].text)
			}
		}
	}
</script>