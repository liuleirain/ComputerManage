import { useComputerStore } from "./modulers/computer";
import { useDepartmentStore } from "./modulers/department";
import { useGroupStore } from "./modulers/group";
import { useAuthStore} from "./modulers/auth"

export default function useStore(){
    return {
        computer: useComputerStore(),
        group: useGroupStore(),
        department: useDepartmentStore(),
        auth : useAuthStore()
    };
}