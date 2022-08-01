排版 左图片封面 右标题 介绍等
<template>
	<view>
		<bpw-list v-if="list.length != 0" :list="list" v-slot="{data, index}" class="commodity">
			<view class="hx">
				<navigator class="href zj-nr-p" :url="data.href" :hover-stay-time="100">
					<view class="h-100-b flex-center">
						<view class="cover">
							<!-- <u-image class="img" width="100%" height="100%" :src="data.src" :fade="true" duration="450" :lazy-load="true"></u-image> -->
							<image class="w-100-b h-100-b" :src="data.src != '' && data.src != null ? data.src : '../../static/none/2.png'" :lazy-load="true" @error="imageError"></image>
						</view>
						<view class="info">
							<view class="head flex-center">
								<view class="title size17 ui-text-xd ui-text-xd-1">{{data.title}}</view>
								<view class="distance" v-if="data.distance">{{data.distance}}</view>
							</view>
							<slot name="remarks" :data="data" :index="index">
								<view class="remarks ui-text-xd ui-text-xd-3" v-html="data.remarks"></view>
							</slot>
							<view class="footer flex-center">
								<slot name="Price" :data="data" :index="index">
									<view class="Price">{{data.Price}}</view>
								</slot>
								<slot name="Sold" :data="data" :index="index">
									<view class="Sold">{{data.Sold}}</view>
								</slot>
							</view>
						</view>
					</view>
				</navigator>
				<slot name="Other" :data="data" :index="index"></slot>
			</view>
		</bpw-list>
        <app-empty v-else mode="list" title=" "></app-empty>
	</view>
</template>

<script>
    export default {
		name: 'bpw-commodity',
		props:{
			list:{
				type:Array,
				default: function() {
					return [];
				}
			}
		},
        methods: {
			imageError: function(e) {
				let url = e.detail.errMsg;
				url = url.replace('GET ','');
				url = url.replace(' 404 (Not Found)','');
				
                this.list.filter(item => {
                    if(item.src == url){
                        item.src = '../../static/none/1.png'
                    }
                })
			}
		}
    };
</script>

<style lang="less">
.commodity{
	/deep/ .li{
		margin-bottom: 0px;
	}
	/deep/ .li:last-child .hx:after{ display: none; }
	
	.href{
		height: 235.5upx;
	}
	.cover{
		width: 33%;
		height: 100%;
		.img{
			width: 100%;
			height: 100%;
		}
	}
	.info{
		width: calc(100% - 36%);
		height: 100%;
		font-size: 25.36upx;
		position: relative;
		.head{
			margin-bottom: 14.49upx;
			.title{
				font-weight: bold;
			}
			.distance{
				color: #B3B3B3;
			}
		}
		.remarks{
			color: #B3B3B3;
		}
		.footer{
			position: absolute;
			bottom: 0px;
			width: 100%;
			.Price{
				font-size: 32.6upx;
				color: #FF0000;
				font-weight: bold;
			}
			.Sold{
				color: #B3B3B3;
			}
		}
	}
}
</style>