<!--
 * @Name: 用户登录
 * @Author: bpwen.cn
 * @Date: 2021-11-17 23:47:37
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-24 09:28:54
-->

<template>
	<app-container :bjColor="true">
		<view class="content">
			<view class="header">
				<image src="../../static/shilu-login/logo.png"></image>
			</view>
			
			<view class="list">
				<view class="list-call">
					<u-icon size="40" name="account-fill" color="#b3c2c9"></u-icon>
					<input class="sl-input" v-model="username" type="text" maxlength="11" placeholder="请输入帐号" />
				</view>
				<view class="list-call">
					<u-icon size="40" name="lock-fill" color="#b3c2c9"></u-icon>
					<input class="sl-input" v-model="password" type="text" maxlength="32" placeholder="请输入密码" password="true" />
				</view>
			</view>
	
			<view class="button-login" :class="{'button-hover': show}" hover-class="button-hover" @tap="submit()">
				<u-loading mode="circle" color="#40cdeb" class="m-10-r" v-if="show"></u-loading>
				<text>{{ show ? '登录中' : '登录'}}</text>
			</view>
		</view>
	</app-container>
</template>

<script>
	import { login, usertoken } from '@/api/user/user'
	
	export default {
		data() {
			return {
				username: '玉玄道',
				password: 'yxd999999',
				show: false
			};
		},
		methods: {
			submit() {
				if(!this.show){
					// if (this.username == '') {
					// 	uni.showToast({
					// 		icon: 'none',
					// 		title: '手机号码不能为空'
					// 	});
					// 	return;
					// }
					
					// if (this.password == '') {
					// 	uni.showToast({
					// 		icon: 'none',
					// 		title: '密码不能为空'
					// 	});
					// 	return;
					// }else if (this.password.length < 6) {
					// 	uni.showToast({
					// 		icon: 'none',
					// 		title: '密码不正确'
					// 	});
					// 	return;
					// }
					
					this.show = true;
					this.onLogin();
				}
			},
			onLogin(){
				let _this = this;
				
				// login({
				// 	username: this.username,
				// 	password: this.password
				// })
                usertoken({
                    appSecret:'e51898ff85c8437790c9c0967ab7a419'
                }).then(res => {
					this.show = false;
					
					let data = res.data
					if(data.Success){
						uni.setStorage({
							key: 'yxd_net_token',
							data: data.Token,
							success: function () {
								uni.showToast({
									icon: 'none',
									title: '登录成功'
								});
								
								const fullPath = uni.getStorageSync('fullPath')
								if(fullPath != ''){
									uni.removeStorage({
										key: 'fullPath',
										success: function (res) {
											//关闭当前页面，跳转到应用内的某个页面。
											uni.redirectTo({
												url: fullPath
											});
										}
									});
								}else{
									uni.redirectTo({
										url: '/'
									});
								}
							}
						});
					}
				}).catch((err) => {
					this.show = false;
					
					uni.showToast({
						icon: 'none',
						title: err
					});
				});
			}
		}
	}
</script>

<style lang="less" scoped>
	.content {
		display: flex;
		flex-direction: column;
		justify-content: center;
		padding-top: 80rpx;
	}

	.header {
		width: 161rpx;
		height: 161rpx;
		background: rgba(63, 205, 235, 1);
		box-shadow: 0rpx 12rpx 13rpx 0rpx rgba(63, 205, 235, 0.47);
		border-radius: 50%;
		margin-top: 30rpx;
		margin-left: auto;
		margin-right: auto;
	}

	.header image {
		width: 161rpx;
		height: 161rpx;
		border-radius: 50%;
	}

	.list {
		margin-top: 15%;
		display: flex;
		flex-direction: column;
		padding: 50rpx 70rpx 0rpx 70rpx;
		margin-top: 100rpx;
	}

	.list-call {
		display: flex;
		flex-direction: row;
		justify-content: space-between;
		align-items: center;
		height: 100rpx;
		color: #333333;
		border-bottom: 0.5px solid #e2e2e2;
	}

	.list-call .img {
		width: 40rpx;
		height: 40rpx;
	}

	.list-call .sl-input {
		flex: 1;
		text-align: left;
		font-size: 32rpx;
		margin-left: 16rpx;
	}

	.button-login {
		color: #FFFFFF;
		font-size: 34rpx;
		width: 85%;
		height: 85rpx;
		line-height: 85rpx;
		background: #b3c2c9;
		border-radius: 50rpx;
		
		text-align: center;
		margin-left: auto;
		margin-right: auto;
		margin-top: 100rpx;
	}

	.button-hover {
		background: #607D8B;
	}

	.agreenment {
		display: flex;
		flex-direction: row;
		justify-content: center;
		align-items: center;
		font-size: 30rpx;
		margin-top: 80rpx;
		color: #9E9E9E;
		text-align: center;
		height: 40rpx;
		line-height: 40rpx;
	}

	.agreenment text {
		font-size: 24rpx;
		margin-left: 15rpx;
		margin-right: 15rpx;
	}
</style>
