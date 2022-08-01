<script>
	import pageAnimation from './bpw-ui/components/page-animation'
	export default {
		mixins: [pageAnimation],
		onLaunch: function() {
			console.log('App Launch');
		},
		onShow: function() {
			console.log('App Show');
		},
		onHide: function() {
			console.log('App Hide');
		}
	};
</script>

<style>
	@import './static/iconfont/iconfont.css';
</style>

<style lang="scss">
	@import "uview-ui/index.scss";
</style>

<style lang="less">
	@import './static/css/mail.less';
	@import './static/css/restructure.less';
</style>