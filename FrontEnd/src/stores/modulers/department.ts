import axios from "axios";
import { defineStore } from "pinia";

export const useDepartmentStore = defineStore('department', {
    state: () => ({
        departments: [] as IDepartment[],
        department: {
            id: 1,
            departmentName: '',
            description: ''
        } as IDepartment,
        newDepartment: {
            id: 1,
            departmentName: '',
            description: ''
        } as IDepartment,
        editVisible: false as boolean,
        createVisible: false as boolean,
        isError: false as boolean,
        message: '' as string,
    }),

    getters: {

    },
    actions: {
        async getDepartments() {
            await axios.get('/api/Departments')
                .then(res => {
                    this.departments = res.data;
                })
                .catch(error => {
                    console.log(error);
                });
        },
        async getDepartment(departmentId: number) {
            await axios.get(`/api/Departments/${departmentId}`)
                .then(res => {
                    this.department = res.data;
                    this.editVisible = !this.editVisible;
                })
                .catch(error => {
                    console.log(error);
                })
        },
        async updateDepartment(departmentId: number) {
            await axios.put(`/api/Departments/${departmentId}`, this.department,
            {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res => {
                    this.editVisible = !this.editVisible;
                    this.getDepartments();
                })
                .catch(error => {
                    console.log(error);
                    this.isError = true;
                    this.message = error.response.statusText;
                    setTimeout(() => {
                        this.isError = false;
                        this.message = ''
                    }, 3000)
                })
        },
        async deleteDepartment(departmentId: number) {
            await axios.delete(`/api/Departments/${departmentId}`,
            {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res => {
                    this.editVisible = !this.editVisible;
                    this.getDepartments();
                })
                .catch(error => {
                    console.log(error);
                    this.isError = true;
                    this.message = error.response.statusText;
                    setTimeout(() => {
                        this.isError = false;
                        this.message = ''
                    }, 3000)
                })
        },
        async createDepartment() {
            await axios.post(`/api/Departments/`, {
                departmentName: this.newDepartment.departmentName,
                description: this.newDepartment.description
            },
            {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res => {
                    if (res.data.isSuccess === true) {
                        this.newDepartment = {
                            id: 0,
                            departmentName: '',
                            description: ''
                        };
                        this.createVisible = !this.createVisible;
                        this.getDepartments();
                    }
                    else {
                        this.isError = true;
                        this.message = res.data.message;
                        setTimeout(() => {
                            this.isError = false;
                        },
                            3000);
                    }
                })
                .catch(error => {
                    console.log(error);
                    this.isError = true;
                    this.message = error.response.statusText;
                    setTimeout(() => {
                        this.isError = false;
                        this.message = ''
                    }, 3000)
                })
        },
        openCloseEditModal() {
            this.editVisible = !this.editVisible;
        },
        openCloseCreateModal() {
            this.createVisible = !this.createVisible;
        }
    }
})