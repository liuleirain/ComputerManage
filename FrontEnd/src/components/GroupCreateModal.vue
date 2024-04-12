<template>
    <!-- Button trigger modal -->
    <button @click="group.openCloseCreateModal()" type="button" class="btn btn-light btn-sm ms-3" data-bs-toggle="modal"
        data-bs-target="#exampleModal">
        <img src="../assets/computer/plus-lg.svg" width="13" />
    </button>

    <!-- Modal -->
    <div v-if="group.createVisible" class="modal fade show" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-modal="true" role="dialog" style="display:block ">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">新增分组</h1>
                    <button @click="group.openCloseCreateModal()" type="button" class="btn-close"
                        aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="groupNameTextInput" class="form-label">组名</label>
                        <input v-model="group.newGroup.groupName" type="text" id="groupNameTextInput"
                            class="form-control input-sm" placeholder="输入组名">
                    </div>

                    <div class="mb-3">
                        <label for="groupModalDepartmentSelect" class="form-label">部门</label>
                        <select id="groupModalDepartmentSelect" v-model="group.newGroup.departmentId"
                            class="form-select">
                            <option v-for="item in department.departments" :key="item.id" :value="item.id">
                                {{ item.departmentName }}</option>
                        </select>
                    </div>
                    <div class="mb-3">
                        <label for="descriptionTextarea" class="form-label">描述</label>
                        <textarea class="form-control" v-model="group.newGroup.description" id="descriptionTextarea"
                            rows="3"></textarea>
                    </div>
                </div>
                <span v-if="group.isError" class="alert alert-danger" role="alert">
                    {{ group.message }}
                </span>
                <div class="modal-footer">
                    <button @click="group.createGroup()" type="button" class="btn btn-primary">新增</button>
                    <button @click="group.openCloseCreateModal()" type="button" class="btn btn-secondary">关闭</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import useStore from '../stores'
const { computer, group, department } = useStore()


</script>

<style scoped></style>