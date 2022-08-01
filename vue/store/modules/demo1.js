/*
 * @Name: 
 * @Author: bpwen.cn
 * @Date: 2021-11-19 17:31:00
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-19 17:37:57
 * @url: 
 */
const state = {
    list:[
        { name:'首页', active: true, path: '/index'}
    ],
    active:[]
}

const mutations = {
    SET_LIST: (state, list) => {
        state.list.push(list)
    },
    SET_ACTIVE: (state, active) => {
        state.active = [
            active
        ]
    }
}

const actions = {
    addList({ commit, dispatch }, params) {
        return new Promise(resolve => {
            let bool = true;
            state.list.filter((item) => {
                if (item.path == params.path) {
                    bool = false  
                }
            })
            
            if(bool){
                dispatch('closeActive')
                commit('SET_LIST', params)
                commit('SET_ACTIVE', params)
            }else{
                dispatch('currentActive', params)
            }
            resolve()
        })
    },
    closeActive(){
        return new Promise(resolve => {
            state.list.filter(function (p) {
                if(p.active){
                    return p.active = false
                }
            })
            resolve()
        })
    },
    currentActive({ commit, dispatch }, params){
        return new Promise(resolve => {
            dispatch('closeActive')
            state.list.filter((item) => {
                if (item.path == params.path) {
                    commit('SET_ACTIVE', params)
                    return item.active = true
                }
            })
            resolve()
        })
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}