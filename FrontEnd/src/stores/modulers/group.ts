import axios from "axios";
import { defineStore } from "pinia";

import { useComputerStore } from '@/stores/modulers/computer'

export const useGroupStore = defineStore('group', {
    state: () => ({
        groups: [] as IGroup[],
        group: {
            id: 1,
            groupName: '',
            departmentId: 1,
            description: ''
        } as IGroup,
        newGroup: {
            id: 1,
            groupName: '',
            departmentId: 1,
            description: ''
        } as IGroup,
        editVisible: false as boolean,
        createVisible: false as boolean,
        isError: false as boolean,
        message: '' as string,
    }),
    getters: {
        editFilterGroups: (state) => {
            return () => {
                const computer = useComputerStore();
                return state.groups.filter(item => item.departmentId === computer.computer.departmentId)
            }
        },
        createFilterGroups: (state) => {
            return () => {
                const computer = useComputerStore();
                return state.groups.filter(item => item.departmentId === computer.newComputer.departmentId)
            }
        }
    },
    actions: {
        async getGroups() {
            await axios.get('/api/WorkingGroups')
                .then(res => {
                    this.groups = res.data;
                })
                .catch(error => {
                    console.log(error);
                });
        },
        async getGroup(groupId: number) {
            if (groupId === null) groupId = 1;
            await axios.get(`/api/WorkingGroups/${groupId}`)
                .then(res => {
                    this.group = res.data;
                    this.editVisible = !this.editVisible;
                })
                .catch(error => {
                    console.log(error);
                });
        },
        async updateGroup(groupId: number) {
            await axios.put(`/api/WorkingGroups/${groupId}`, this.group,
            {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res => {
                    this.editVisible = !this.editVisible;
                    this.getGroups();
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
        async deleteGroup(groupId: number) {
            await axios.delete(`/api/WorkingGroups/${groupId}`,
            {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res => {
                    this.editVisible = !this.editVisible;
                    this.getGroups();
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
        async createGroup() {
            await axios.post(`/api/WorkingGroups/`, {
                groupName: this.newGroup.groupName,
                departmentId: this.newGroup.departmentId,
                description: this.newGroup.description
            },
            {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem('token')}`
                }
            })
                .then(res => {
                    if (res.data.isSuccess === true) {
                        this.newGroup = {
                            id: 0,
                            groupName: '',
                            departmentId: 0,
                            description: ''
                        };
                        this.createVisible = !this.createVisible;
                        this.getGroups();
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