/*
uni-app挂载配置pages.json如下
"easycom": {
	"^bpw-(.*)": "@/bpw-ui/components/bpw-$1/bpw-$1.vue"
}

H5在main.js配置如下
import bpwui from "@/bpw-ui/index.js";
Vue.use(bpwui);
*/

const components = {
	'bpw-list': () => import('./components/bpw-list/bpw-list.vue'),
	'bpw-img': () => import('./components/bpw-img/bpw-img.vue'),
	'bpw-head': () => import('./components/bpw-head/bpw-head.vue'),
	'bpw-heada': () => import('./components/bpw-heada/bpw-heada.vue'),
	'bpw-mail': () => import('./components/bpw-mail/bpw-mail.vue'),
	'bpw-nav': () => import('./components/bpw-nav/bpw-nav.vue'),
	'bpw-slide': () => import('./components/bpw-slide/bpw-slide.vue'),
	'bpw-card': () => import('./components/bpw-card/bpw-card.vue'),
	'bpw-commodity': () => import('./components/bpw-commodity/bpw-commodity.vue'),
	'bpw-navigator': () => import('./components/bpw-navigator/bpw-navigator.vue'),
	'bpw-label': () => import('./components/bpw-label/bpw-label.vue'),
	'bpw-loadmore': () => import('./components/bpw-loadmore/bpw-loadmore.vue'),
	'bpw-nav-type': () => import('./components/bpw-nav-type/bpw-nav-type.vue')
};

const install = function(Vue, opts = {}) {
	Object.keys(components).forEach((key) => {
		Vue.component(key, components[key]);
	});
};
export default install;