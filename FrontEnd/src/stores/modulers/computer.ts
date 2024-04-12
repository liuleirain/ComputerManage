import axios from "axios";
import { defineStore } from "pinia";
import useStore from '@/stores'

export const useComputerStore = defineStore(
    'computer',
    {
        state: () => ({
            computers: [] as IComputer[],
            computer: {
                id: 0,
                hostName: '',
                ipAddress: '',
                serialNumber: '',
                quickServiceCode: '',
                user: '',
                departmentId: 0,
                groupId: 0,
                remark: ''
            } as IComputer,
            newComputer: {
                id: 0,
                hostName: '',
                ipAddress: '',
                serialNumber: '',
                quickServiceCode: '',
                user: '',
                departmentId: 0,
                groupId: 0,
                remark: ''
            } as IComputer,
            searchData: '' as string,
            isSuccess: false as boolean,
            isError: false as boolean,
            errorlist: [] as string[],
            message: '' as string,
            orderBy: '' as string,
            direction: '' as string | boolean
        }),

        getters: {
            filterComputers: (state) => {
                return () => {
                    if (state.searchData === '') {
                        return state.computers;
                    }
                    let regex = new RegExp(`^${state.searchData}`, "gi")
                    return state.computers.filter(item => {
                        return item.serialNumber.match(regex);
                    })
                };
            }
        },

        actions: {
            async getComputers() {
                let res = await axios.get('/api/Computers');
                this.computers = res.data;
            },
            async getComputer(computerId: number) {
                await axios.get(`/api/Computers/${computerId}`)
                    .then(res => {
                        this.computer = res.data;
                    })
                    .catch(error => {
                        console.log(error);

                    });
            },
            async updateComputer(computerId: number) {
                await axios.put(`/api/Computers/${computerId}`, this.computer,
                    {
                        headers: {
                            Authorization: `Bearer ${localStorage.getItem('token')}`
                        }
                    })
                    .then(res => {
                        if (res.data.isSuccess) {
                            this.isSuccess = res.data.isSuccess;
                            this.message = res.data.message;
                        }
                        else {
                            this.isError = !res.data.isSuccess;
                            this.message = res.data.message;
                        }
                        this.getComputers();
                        setTimeout(() => {
                            this.isSuccess = false;
                            this.isError = false;
                        },
                            3000);
                    })
                    .catch(error => {
                        console.log(error);
                        this.isError = true;
                        this.message = error.response.statusText;
                        setTimeout(() => {
                            this.isError = false;
                            this.message = ''
                        }, 3000)
                    });
            },
            async deleteComputer(computerId: number) {
                var res = await axios.delete(`/api/Computers/${computerId}`,
                {
                    headers: {
                        Authorization: `Bearer ${localStorage.getItem('token')}`
                    }
                })
                    .then(res => {
                        if (res.data.isSuccess) {
                            this.isSuccess = res.data.isSuccess;
                            this.message = res.data.message;
                            this.computer = {
                                id: 0,
                                hostName: '',
                                ipAddress: '',
                                serialNumber: '',
                                quickServiceCode: '',
                                user: '',
                                departmentId: 0,
                                groupId: 0,
                                remark: ''
                            }
                        }
                        else {
                            this.isError = !res.data.isSuccess;
                            this.message = res.data.message;
                        }
                        this.getComputers();
                        setTimeout(() => {
                            this.isSuccess = false;
                            this.isError = false;
                        },
                            3000);
                    })
                    .catch(error => {
                        console.log(error);
                    this.isError = true;
                    this.message = error.response.statusText;
                    setTimeout(() => {
                        this.isError = false;
                        this.message = ''
                    }, 3000)
                    });
            },
            async createComputer() {
                var mythis = this;
                const auth = useStore()
                var res = await axios.post('/api/Computers', {
                    hostName: this.newComputer.hostName,
                    ipAddress: this.newComputer.ipAddress,
                    serialNumber: this.newComputer.serialNumber,
                    quickServiceCode: this.newComputer.quickServiceCode,
                    user: this.newComputer.user,
                    departmentId: this.newComputer.departmentId,
                    groupId: this.newComputer.groupId,
                    remark: this.newComputer.remark
                },
                {
                    headers: {
                        Authorization: `Bearer ${localStorage.getItem('token')}`
                    }
                }
                )
                    .then(res => {
                        if (res.data.isSuccess) {
                            this.isSuccess = res.data.isSuccess;
                            this.message = res.data.message;
                            this.newComputer = {
                                id: 0,
                                hostName: '',
                                ipAddress: '',
                                serialNumber: '',
                                quickServiceCode: '',
                                user: '',
                                departmentId: 0,
                                groupId: 0,
                                remark: ''
                            }
                        }
                        else {
                            this.isError = !res.data.isSuccess;
                            this.message = res.data.message;
                        }
                        setTimeout(() => {
                            this.isSuccess = false;
                            this.isError = false;
                        },
                            3000);
                    })
                    .catch(function (error) {
                        if (error.response) {
                            if (error.response.status == 400) {
                                mythis.errorlist = error.response.data.errors.SerialNumber;
                            }
                            console.log(error.response.data);
                            console.log(error.response.status);
                            console.log(error.response.headers);
                        } else if (error.request) {
                            console.log(error.request);
                        } else {
                            console.log('Error', error.message);
                        }
                        console.log(error.config);
                    });
            },
            async sortData(source: string) {
                if (this.orderBy !== source)
                    this.direction = '';
                this.orderBy = source;
                if (this.direction === '' || this.direction === 'desc') {
                    this.direction = 'asc';
                }
                else {
                    this.direction = 'desc';
                }
                switch (this.orderBy) {
                    case 'hostName':
                        await this.computers.sort((a: IComputer, b: IComputer): number => {
                            return (this.direction === 'asc' ? a : b).hostName === (this.direction === 'asc' ? b : a).hostName ? 0 :
                                (this.direction === 'asc' ? a : b).hostName > (this.direction === 'asc' ? b : a).hostName ? 1 : -1
                        })
                        break;
                    case 'ipAddress':
                        await this.computers.sort((a: IComputer, b: IComputer): number => {
                            let ip1 = "";
                            let ip2 = "";
                            if (a.ipAddress)
                                ip1 = a.ipAddress.split('.').map(el => el.padStart(3, '0')).join('');
                            if (b.ipAddress)
                                ip2 = b.ipAddress.split('.').map(el =>
                                    el.padStart(3, '0')).join('');
                            return (this.direction === 'asc' ? ip1 : ip2) === (this.direction === 'asc' ? ip2 : ip1) ? 0 :
                                (this.direction === 'asc' ? ip1 : ip2) > (this.direction === 'asc' ? ip2 : ip1) ? 1 : -1
                        })
                        break;
                    default:
                        break;
                }
                return;
            }
        }
    })