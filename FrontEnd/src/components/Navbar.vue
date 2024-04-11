<template>
    <main>
        <div >
            <nav class="navbar navbar-expand-lg" style="background-color: #e3f2fd;">
                <div class="container-fluid">
                    <a class="navbar-brand" href="/">首页</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                        data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto  mb-2 mb-lg-0">
                            <li class="nav-item">
                                <!-- <RouterLink class="nav-link active" to="/">Home</RouterLink> -->
                            </li>
                        </ul>
                        <div class="d-flex">
                            <RouterLink v-if="!auth.isAuthenticated" to="/auth/login" class="btn btn-primary">登录</RouterLink>
                            <button v-else class="btn btn-primary" @click="auth.handlerLogout()">退出</button>
                        </div>
                    </div>
                </div>
            </nav>
        </div>
    </main>
</template>

<script setup lang="ts">
import useStore from "../stores";
const { computer, group, department,auth } = useStore();
computer.getComputers();
group.getGroups();
department.getDepartments();
</script>