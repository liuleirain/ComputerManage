<template>
    <main>
        <div class="container mt-5">
            <form id="createForm">
                <legend class="text-center">新增主机</legend>
                <ul class="alert alert-warning" v-if="Object.keys(computer.errorlist).length > 0">
                    <li class="mb-0 ms-3" v-for="(error, index) in computer.errorlist" :key="index">{{ error }}</li>
                </ul>
                <div class="container px-4 text-left">
                    <div class="row gx-5">
                        <div class="col">
                            <div class="mb-3">
                                <label for="serialNumberTextInput" class="form-label">序列号</label>
                                <input type="text" v-model="computer.newComputer.serialNumber"
                                    id="serialNumberTextInput" class="form-control input-sm" placeholder="输入序列号">
                            </div>
                            <div class="mb-3">
                                <label for="quickServiceCodeTextInput" class="form-label">快速服务代码</label>
                                <input type="text" v-model="computer.newComputer.quickServiceCode"
                                    id="quickServiceCodeTextInput" class="form-control input-sm" placeholder="输入快速服务代码">
                            </div>
                            <div class="mb-3">
                                <label for="workingGroupSelect" class="form-label">组名
                                    <GroupCreateModal />
                                    <GroupEditModal />
                                </label>
                                <select id="workingGroupSelect" v-model="computer.newComputer.groupId"
                                    class="form-select">
                                    <option v-for="item in group.createFilterGroups()" :key="item.id" :value="item.id">
                                        {{
                    item.groupName }}</option>
                                </select>
                            </div>
                        </div>
                        <div class="col">
                            <div class="mb-3">
                                <label for="hostNameTextInput" class="form-label">主机名</label>
                                <input type="text" v-model="computer.newComputer.hostName" id="hostNameTextInput"
                                    class="form-control input-sm" placeholder="输入主机名">
                            </div>
                            <div class="mb-3">
                                <label for="userTextInput" class="form-label">使用人</label>
                                <input type="text" v-model="computer.newComputer.user" id="userTextInput"
                                    class="form-control input-sm" placeholder="输入使用人">
                            </div>
                        </div>
                        <div class="col">
                            <div class="mb-3">
                                <label for="ipAddressTextInput" class="form-label">IP地址</label>
                                <input type="text" v-model="computer.newComputer.ipAddress" id="ipAddressTextInput"
                                    class="form-control input-sm" placeholder="输入IP地址">
                            </div>
                            <div class="mb-3">
                                <label for="departmentSelect" class="form-label">部门</label>
                                <select id="departmentSelect" v-model="computer.newComputer.departmentId"
                                    class="form-select">
                                    <option v-for="item in department.departments" :key="item.id" :value="item.id">
                                        {{ item.departmentName }}</option>
                                </select>
                            </div>
                            <div class="mb-3">
                                <div class="mb-3">
                                    <label for="remarkTextarea" class="form-label">备注</label>
                                    <textarea id="remarkTextarea" class="form-control"
                                        v-model="computer.newComputer.remark" rows="3"></textarea>
                                </div>
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
                    <button type="button" @click="computer.createComputer()" class="btn btn-primary 
                             m-1">保存</button>

                    <RouterLink class="btn btn-secondary m-1" to="/">返回</RouterLink>
                </div>
            </form>
        </div>
    </main>
</template>

<script setup lang="ts">
import useStore from '@/stores';
import GroupEditModal from '@/components/GroupEditModal.vue';
import GroupCreateModal from '@/components/GroupCreateModal.vue';
const { computer, group, department } = useStore();


</script>

<style scoped></style>