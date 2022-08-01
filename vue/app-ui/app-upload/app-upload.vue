<!--
 * @Name: 图片上传
 * @Author: bpwen.cn
 * @Date: 2021-11-05 10:54:55
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-05 10:54:55
 * @url: https://www.uviewui.com/components/upload.html
-->

<template>
	<u-upload
	class="flex"
	ref="uUpload"
	:auto-upload="false"
	:action="action"
	:width="width"
	:height="height"
	:max-size="maxSize"
	:max-count="maxCount"
	:show-tips="false"
	:file-list="fileList"
	@on-remove="onRemove"></u-upload>
</template>

<script>
	export default {
		name:'app-enterprise-scale',
		props:{
			show:{
				type: Boolean,
				default: false
			},
			value: {
				type: [Array, Object],
				default: []
			},
		},
		data() {
			return {
				maxCount:9,//限制图片数量
				maxSize:5 * 1024 * 1024,//限制图片数量和大小
				width: 210,
				height: 210,
				// 演示地址，请勿直接使用
				action: 'http://www.example.com/upload',
				//图片列表
				fileList: [
					// {
					// 	url: 'http://pics.sc.chinaz.com/files/pic/pic9/201912/hpic1886.jpg',
					// }
				]
			}
		},
		watch:{
			value: {
				deep: true,
				immediate: true,
				handler: function (v) {
					this.fileList = v
				}
			}
		},
		methods: {
			onUpload(){
				this.$refs.uUpload.upload();
				
				let files = [];
				// 通过filter，筛选出上传进度为100的文件(因为某些上传失败的文件，进度值不为100，这个是可选的操作)
				files = this.$refs.uUpload.lists.filter(val => {
					return val.progress == 100;
				})
				// 如果您不需要进行太多的处理，直接如下即可
				// files = this.$refs.uUpload.lists;
				console.log(files)
			},
			onRemove(index, lists) {
				console.log('图片已被移除')
			}
		}
	}
</script>

<style>
</style>
