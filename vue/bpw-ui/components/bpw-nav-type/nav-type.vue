<template>
	<view class="nav-type">
		<bpw-list :list="ArrList" :row="row">
			<template v-slot="{data, index}">
                <template  v-if="data.href">
                    <navigator :url="data.href" hover-class="none">
                        <image class="cover" :src="data.src" lazy-load="true"></image>
                        <text class="title">{{data.name}}</text>
                    </navigator>
                </template>
                <template v-else>
                    <view @click="onClick(data)">
						<image class="cover" :src="data.src" lazy-load="true"></image>
						<text class="title">{{data.name}}</text>
					</view>
                </template>
			</template>
		</bpw-list>
	</view>
</template>

<script>
	export default{
		name:"home-nav-type",
		props:{
			list:{
				type: [String, Array],
				default: function() {
					return [];
				}
			},
			row:{
				type:Number,
				default:4
			}
		},
        data() {
            return {
                ArrList: []
            }
        },
        watch:{
            list: {
                deep: true,
                immediate: true,
                handler: function (v) {
                    this.ArrList = v
                }
            },
        },
		methods:{
			onClick(data){
				if(data.click !== undefined){
					this.$emit("receipt", data)
				}
			}
		}
	}
</script>

<style lang="less" scoped>
.nav-type{
	padding-top: 36.23upx;
	padding-bottom: 18.11upx;
	text-align: center;
	.cover{
		width: 81.52upx;
		height: 81.52upx;
	}
	.title{
		display:block;
		padding: 9.05upx 0px;
		width: 100%;
		font-size: 25.36upx;
	}
}
</style>