<template>
    <main>
        <div class="container mt-3">
            <div class="row text-center align-items-start mt-3 mb-2">
                <div class="col">
                    <h2 class="">主机信息查询 <img src="../../assets/computer/pc-display.svg" alt="Bootstrap" width="26"
                            height="26" /></h2>
                </div>
                <div class="col">
                    <input id="searchTextInput" class="form-control me-auto" placeholder="序列号搜索" type="text"
                        v-model="computer.searchData">
                </div>
                <div class="col">
                    <RouterLink class="btn btn-primary w-5" to="/computers/create">新增主机</RouterLink>
                </div>
            </div>
            <table class="table table-bordered">
                <thead>
                    <tr class="table-secondary text-center">
                        <th scope="col">#</th>
                        <th scope="col">序列号</th>
                        <th scope="col" @click="computer.sortData('hostName')" style="cursor:pointer">主机名
                            <img v-if="computer.orderBy === 'hostName' && computer.direction === 'asc'"
                                src="../../assets/computer/sort-up-alt.svg" />
                            <img v-if="computer.orderBy === 'hostName' && computer.direction === 'desc'"
                                src="../../assets/computer/sort-up.svg" />
                        </th>
                        <th scope="col" @click="computer.sortData('ipAddress')" style="cursor:pointer">IP地址
                            <img v-if="computer.orderBy === 'ipAddress' && computer.direction === 'asc'"
                                src="../../assets/computer/sort-up-alt.svg" />
                            <img v-if="computer.orderBy === 'ipAddress' && computer.direction === 'desc'"
                                src="../../assets/computer/sort-up.svg" />
                        </th>
                        <th scope="col">使用人</th>
                        <th scope="col"></th>
                    </tr>
                </thead>
                <tbody v-if="computer.computers.length > 0">
                    <tr class="text-center" v-for="(item, index) in computer.filterComputers()" :key="item.id">
                        <td>{{ index + 1 }}</td>
                        <td>{{ item.serialNumber
                            }}</td>
                        <td>{{ item.hostName }}
                        </td>
                        <td>{{ item.ipAddress
                            }}</td>
                        <td>{{ item.user }}</td>
                        <td>
                            <RouterLink :to="{ path: '/computers/edit/' + item.id }" class="btn btn-light btn-sm"><img
                                    src="../../assets/computer/pen.svg" width="13" />
                            </RouterLink>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </main>
</template>


<script setup lang="ts">
import useStore from "../../stores";
const { computer, group, department } = useStore();

</script>

<style scoped>
.table tbody tr td {
    vertical-align: middle
}
</style>