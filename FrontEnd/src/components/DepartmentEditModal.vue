<template>
    <!-- Button trigger modal -->
    <button @click="department.getDepartment(computer.computer.departmentId)" type="button" class="btn btn-light btn-sm"
        data-bs-toggle="modal" data-bs-target="#exampleModal">
        <img
                                    src="../assets/computer/pen.svg" width="13"/>
    </button>

    <!-- Modal -->
    <div v-if="department.editVisible" class="modal fade show" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-modal="true" role="dialog" style="display:block ">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">编辑部门</h1>
                    <button @click="department.openCloseEditModal()" type="button" class="btn-close" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="departmentNameTextInput" class="form-label">部门名</label>
                        <input v-model="department.department.departmentName" type="text" id="departmentNameTextInput"
                            class="form-control input-sm" placeholder="输入部门名">
                    </div>

                    <div class="mb-3">
                        <label for="descriptionTextarea" class="form-label">描述</label>
                        <textarea class="form-control" v-model="department.department.description" id="descriptionTextarea"
                            rows="3"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button @click="department.updateDepartment(group.group.id)" type="button" class="btn btn-primary">修改</button>
                        <button type="button" @click="department.deleteDepartment(department.department.id)"
                            class="btn btn-danger m-1">删除</button>
                    <button @click="department.openCloseEditModal()" type="button" class="btn btn-secondary">关闭</button>
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