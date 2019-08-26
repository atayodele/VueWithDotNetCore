<template>
    <div class="row my-5">
        <div class="col-md-6 offset-md-3">
            <div class="card">
                <div class="card-body">
                    <h3 class="text-center my-2">Login</h3>
                    <div class="form-group">
                        <input v-bind:class="{ 'is-invalid': errors.email, 'is-valid': !errors.email && this.submitted }"  v-model="email" type="text" placeholder="Email" class="form-control">
                        <div class="errors" v-if="errors.email">
                            <small class="text-danger" :key="error" v-for="error in errors.email">{{error}}</small>
                        </div>
                    </div>
                    <div class="form-group">
                        <input v-bind:class="{ 'is-invalid': errors.password, 'is-valid': !errors.password && this.submitted }" v-model="password" type="password" placeholder="Password" class="form-control">
                        <div class="errors" v-if="errors.password">
                            <small class="text-danger" :key="error" v-for="error in errors.password">{{error}}</small>
                        </div>
                    </div>
                    <div class="form-group">
                        <button @click="loginUser()" :disabled="loading" class="btn btn-success form-control">                            
                            <i class="fas fa-spin fa-spinner" v-if="loading"></i>
                            {{ loading ? '' : 'Login' }}
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Axios from 'axios';
import config from '@/config';

export default {
    beforeRouteEnter(to, from, next) {
        //console.log(to, from, next);
        if(localStorage.getItem("auth")){
            return next({ path: "/" });
        }
        next();
    },
    data() {
        return{
            email: '',
            password: '',
            errors: {},
            submitted: false,
            loading: false
        }
    },
    methods: {
        loginUser() {
            this.loading = true;
            console.log(this.email, this.password);
            Axios.post(`${config.apiUrl}/auth/login`, {
                email: this.email, password: this.password
            })
            .then((response) => {
                this.loading = false;
                this.submitted = true;
                const { data } = response.data;
                localStorage.setItem('auth', JSON.stringify(data))
                this.$root.auth = data;
                this.$noty.success("Successfully logged in.");

                this.$router.push('/');

                //console.log(response);
            })
            .catch(({ response }) => {
                this.loading = false;
                this.submitted = true;
                //console.log(response);
                this.$noty.error("Oops, something went wrong!");
                if(response.status === 401) {
                    this.errors = {
                        email: ['These credentials do not match our records.'],
                        password: ['These credentials do not match our records.']
                    };
                } else {
                    this.errors = response.data;
                }
            });
        }
    }
}
</script>