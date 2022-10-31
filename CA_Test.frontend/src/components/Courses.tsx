import {useEffect, useState} from "react";
import axios from "axios";
import { useAuth } from "@/context/AuthUserContext"

export default function Courses() {
    const { authUser } : {authUser : any} = useAuth()
    const [course, setCourses] = useState<Array<any>>()
    useEffect(() => {
        getAllCourse()
    }, [])

    const getAllCourse = async () => {
        try{
            const students = await axios.get(`https://localhost:7010/Auth/Courses/${authUser?.id}`, { headers: { "Authorization": `Bearer ${authUser?.token}` } })
            console.log(students?.data);
            setCourses(students?.data)
        } catch(error){
          console.log(error)
          if(error?.message){
            console.log(error)
          }
        }
      }
  return (
    <>
    <div className="border-b border-gray-200 bg-white px-4 py-5 sm:px-6">
      <h3 className="text-lg font-medium leading-6 text-gray-900">Your Courses</h3>
    </div>
    <ul role="list" className="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-3 pt-4">
      {course && course?.map((Course) => (
        <li key={Course.InstructorId} className="col-span-1 divide-y divide-gray-200 rounded-lg bg-white shadow">
          <div className="flex w-full items-center justify-between space-x-6 p-6">
            <div className="flex-1 truncate">
              <div className="flex items-center space-x-3">
                <h3 className="truncate text-sm font-medium text-gray-900">{Course?.courseTitle}</h3>
                <span className="inline-block flex-shrink-0 rounded-full bg-green-100 px-2 py-0.5 text-xs font-medium text-green-800">
                  {`Fee ${Course?.courseFee}`}
                </span>
              </div>
              <p className="mt-1 truncate text-sm text-gray-500">{Course?.courseDescription}</p>
            </div>
          </div>
          <div>
            <div className="-mt-px flex divide-x divide-gray-200">
              <div className="flex w-0 flex-1">
                <button 
                  className="relative -mr-px inline-flex w-0 flex-1 items-center justify-center rounded-bl-lg border border-transparent py-4 text-sm font-medium text-gray-700 hover:text-gray-500"
                >
                  <span className="ml-3">cancel</span>
                </button>
              </div>
              <div className="-ml-px flex w-0 flex-1">
                <button 
                  className="relative inline-flex w-0 flex-1 items-center justify-center border border-transparent py-4 text-sm font-medium text-gray-700 hover:text-gray-500"
                >
                  <span className="ml-3">hold</span>
                </button>
              </div>
              <div className="-ml-px flex w-0 flex-1">
                <button 
                  className="relative inline-flex w-0 flex-1 items-center justify-center rounded-br-lg border border-transparent py-4 text-sm font-medium text-gray-700 hover:text-gray-500"
                >
                  <span className="ml-3">extend</span>
                </button>
              </div>
            </div>
          </div>
        </li>
      ))}
    </ul>
    </>
  )
}