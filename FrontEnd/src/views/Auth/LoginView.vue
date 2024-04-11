<template>
  <div>
    <section>
      <div class="container mt-5 pt-5">
        <div class="row">
          <div class="col-12 col-sm-7 col-md-6 m-auto">
            <div class="card border-0 shadow">
              <div class="card-body">
                <form @submit.prevent="auth.handlerLogin">
                  <h2 class="text-center">登录</h2>
                  <div class="input-group my-4 ">
                    <span class="input-group-text">
                      <img src="@/assets/computer/person-circle.svg" />
                    </span>
                    <input v-model="auth.userName" type="text" class="form-control" placeholder="账户">
                  </div>
                  <div class="input-group my-4 ">
                    <span class="input-group-text">
                      <img src="@/assets/computer/file-lock-fill.svg" />
                    </span>
                    <input v-model="auth.password" type="password" class="form-control" placeholder="密码">
                  </div>
                  <div class="text-center mt-3">
                    <div v-if="auth.isError" class="alert alert-danger" role="alert">
                        {{ auth.message }}
                    </div>
                    <button class="btn btn-primary" type="submit">登录</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script setup lang="ts">
import useStore from '@/stores';
const { auth } = useStore();
</script>

<style scoped></style>