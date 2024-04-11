import axios from 'axios'
import { defineStore } from 'pinia'
import router from '@/router'

export const useAuthStore = defineStore(
    'auth',
    {
        state: () => ({
            userName: '' as string,
            password: '' as string,
            isAuthenticated: false as boolean,
            token: '' as string,
            isError: false as boolean,
            message: '' as string
        }),

        getters: {

        },

        actions: {
            async handlerLogin() {
                await axios.post('/api/Authen/Login', {
                    userName: this.userName,
                    password: this.password
                })
                    .then(res => {
                        this.token = res.data.message;
                        this.userName = '';
                        this.password = '';
                        this.isAuthenticated = true;
                        router.push('/');
                    })
                    .catch(error => {
                        this.isError = true;
                        this.message = '用户名或密码错误'
                        setTimeout(() => {
                            this.isError = false
                            this.message = ''
                        }, 3000)
                        console.log(error);
                    })
            },
            async handlerLogout() {
                this.token = '';
                this.isAuthenticated = false;
                this.$reset;
            }
        },
        persist: true,
    }
)