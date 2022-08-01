<template>
	<bpw-heada
	title="你好" 
	:iconLeft="['home']"
	:iconRight="['search']"
	type="transparent" 
	:opacityLeft="true"
	:opacityTitle="true"
	:scrollTop="scrollTop"
	></bpw-heada>
</template>

<script>
	export default{
		name:"bpw-head-type",
		props:{
			//位置
			scrollTop:{
				type:Number,
				default: function() {
					return 0;
				}
			}
		}
	}
</script>