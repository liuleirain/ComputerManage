<template>
    <main>
        <div class="container mt-5">
            <form @submit.prevent>
                <fieldset enable>
                    <legend class="text-center">主机信息编辑</legend>
                    <div class="container px-4 text-left">
                        <div class="row gx-5">
                            <div class="col">
                                <div class="mb-3">
                                    <label for="serialNumberTextInput" class="form-label">序列号</label>
                                    <input type="text" v-model="computer.computer.serialNumber"
                                        id="serialNumberTextInput" class="form-control input-sm" placeholder="输入序列号">
                                </div>
                                <div class="mb-3">
                                    <label for="quickServiceCodeTextInput" class="form-label">快速服务代码</label>
                                    <input type="text" v-model="computer.computer.quickServiceCode"
                                        id="quickServiceCodeTextInput" class="form-control input-sm"
                                        placeholder="输入快速服务代码">
                                </div>
                                <div class="mb-3">
                                    <label for="workingGroupSelect" class="form-label">组名<GroupCreateModal /><GroupEditModal /></label>
                                    <select id="workingGroupSelect" v-model="computer.computer.groupId"
                                        class="form-select">
                                        <option v-for="item in group.editFilterGroups()" :key="item.id" :value="item.id">{{
                                        item.groupName }}</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col">
                                <div class="mb-3">
                                    <label for="hostNameTextInput" class="form-label">主机名</label>
                                    <input type="text" v-model="computer.computer.hostName" id="hostNameTextInput"
                                        class="form-control input-sm" placeholder="输入主机名">
                                </div>
                                <div class="mb-3">
                                    <label for="userTextInput" class="form-label">使用人</label>
                                    <input type="text" v-model="computer.computer.user" id="userTextInput"
                                        class="form-control input-sm" placeholder="输入使用人">
                                </div>
                            </div>
                            <div class="col">
                                <div class="mb-3">
                                    <label for="ipAddressTextInput" class="form-label">IP地址</label>
                                    <input type="text" v-model="computer.computer.ipAddress" id="ipAddressTextInput"
                                        class="form-control input-sm" placeholder="输入IP地址">
                                </div>
                                <div class="mb-3">
                                    <label for="departmentSelect" class="form-label">部门<DepartmentCreateModal /><DepartmentEditModal /></label>
                                    <select id="departmentSelect" v-model="computer.computer.departmentId"
                                        class="form-select">
                                        <option v-for="item in department.departments" :key="item.id" :value="item.id">
                                            {{ item.departmentName }}</option>
                                    </select>
                                </div>
                                <div class="mb-3">
                                        <label for="remarkTextarea" class="form-label">备注</label>
                                        <textarea class="form-control" v-model="computer.computer.remark"
                                            id="remarkTextarea" rows="3"></textarea>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="container text-center">
                        <div v-if="computer.isSuccess" class="alert alert-success" role="alert">
                            {{ computer.message }}
                        </div>
                        <div v-if="computer.isError" class="alert alert-danger" role="alert">
                            {{ computer.message }}
                        </div>
                        <button type="submit" @click="computer.updateComputer(Number(route.params.id))" class="btn btn-primary 
                             m-1">修改</button>
                        <button type="submit" @click="computer.deleteComputer(Number(route.params.id))"
                            class="btn btn-danger m-1">删除</button>
                        <RouterLink class="btn btn-secondary m-1" to="/">返回</RouterLink>
                    </div>
                </fieldset>
            </form>
        </div>
    </main>
</template>

<script setup lang="ts">
import GroupEditModal from '@/components/GroupEditModal.vue';
import GroupCreateModal from '@/components/GroupCreateModal.vue';
import DepartmentEditModal from '@/components/DepartmentEditModal.vue';
import DepartmentCreateModal from '@/components/DepartmentCreateModal.vue';
import { useRoute } from "vue-router";
import useStore from "../../stores";
const route = useRoute();
const { computer, group, department } = useStore();

computer.getComputer(Number(route.params.id));
</script>
