<template>
    <!-- Button trigger modal -->
    <button @click="department.openCloseCreateModal()" type="button" class="btn btn-light btn-sm ms-3"
        data-bs-toggle="modal" data-bs-target="#exampleModal">
        <img src="../assets/computer/plus-lg.svg" width="13" />
    </button>

    <!-- Modal -->
    <div v-if="department.createVisible" class="modal fade show" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-modal="true" role="dialog" style="display:block ">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">新增部门</h1>
                    <button @click="department.openCloseCreateModal()" type="button" class="btn-close"
                        aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="departmentNameTextInput" class="form-label">部门名</label>
                        <input v-model="department.newDepartment.departmentName" type="text"
                            id="departmentNameTextInput" class="form-control input-sm" placeholder="输入组名">
                    </div>
                    <div class="mb-3">
                        <label for="descriptionTextarea" class="form-label">描述</label>
                        <textarea class="form-control" v-model="department.newDepartment.description"
                            id="descriptionTextarea" rows="3"></textarea>
                    </div>
                </div>
                <span v-if="department.isError" class="alert alert-danger" role="alert">
                    {{ department.message }}
                </span>
                <div class="modal-footer">
                    <div v-if="department.isError" class="alert alert-danger" role="alert">
                        {{ department.message }}
                    </div>
                    <button @click="department.createDepartment()" type="button" class="btn btn-primary">新增</button>
                    <button @click="department.openCloseCreateModal()" type="button"
                        class="btn btn-secondary">关闭</button>
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