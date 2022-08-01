<template>
	<view class="list page" :class="css != '' ? css : classRow" :style="listStyle">
		<view class="li" v-for="(item, index) in list" :key="index" v-if="list">
			<!--
				外部组件调用
				<template v-slot="{data, index}"></template>
			-->
			<slot :data="item" :index="index"></slot>
		</view>
	</view>
</template>

<script>
    export default {
		name: 'bpw-list',
		props:{
			list:{
				type:Array,
				default: ()=>[]
			},
			/* .row-？ 编号 */
			row:{
				type:Number,
				default: 1
			},
			/*css 类名指定 如：list-row-2 瀑布流布局2行*/
			css:{
				type:String,
				default: ''
			},
			/*标题样式*/
			listStyle:{
				type:String,
				default: ''
			},
			/*列表是否*/
			dividingLine:{
				type:Boolean,
				default: false
			}
		},
		computed: {
			classRow: function () {
				let css = '';
				if(this.css != ''){
					css += this.css
				}else{
					if(this.row >= 1){
						css += 'row row-' + this.row;
					}
				}
				
				if(this.dividingLine){
					css += ' ui-list'
				}
				return css
			}
		}
    };
</script>

<style lang="less" scoped>
	.list{width:100%;
		&.list-row-2{
			column-count: 2;
			.li{
				break-inside: avoid;
				margin-bottom: 0px;
			}
		}
	}
	
	.list:before,.list:after{display: table;content: " ";}
	.list:after{clear: both;}
	
	.list .li {width: 100%; margin-bottom: 18.11rpx;}
	.ui-list {
		.li{
			margin-bottom: 0rpx;
		}
	}
	
	.row .li{float: left;}
	
	.row-2 .li {width: 50%;}
	.row-2 .li:nth-last-child(odd){padding-left: 13.58rpx;}
	.row-2 .li:nth-last-child(even){padding-right: 13.58rpx;}
	
	.row-3 .li {width: 33.33333333%; padding: 0px 13.58rpx;}
	
	.row-4 .li {width: 25%; padding: 0px 13.58rpx;}
	.row-5 .li {width: 20%; padding: 0px 13.58rpx;}
</style>