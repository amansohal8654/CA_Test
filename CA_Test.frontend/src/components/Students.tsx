import { CheckCircleIcon, ChevronRightIcon, EnvelopeIcon } from '@heroicons/react/20/solid'
import { useAuth } from "@/context/AuthUserContext"
import {useState, useEffect} from "react";
import axios from "axios"

const applications = [
  {
    applicant: {
      name: 'Ricardo Cooper',
      email: 'ricardo.cooper@example.com',
      imageUrl:
        'https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
    date: '2020-01-07',
    dateFull: 'January 7, 2020',
    stage: 'Completed phone screening',
    href: '#',
  },
  {
    applicant: {
      name: 'Kristen Ramos',
      email: 'kristen.ramos@example.com',
      imageUrl:
        'https://images.unsplash.com/photo-1550525811-e5869dd03032?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
    date: '2020-01-07',
    dateFull: 'January 7, 2020',
    stage: 'Completed phone screening',
    href: '#',
  },
  {
    applicant: {
      name: 'Ted Fox',
      email: 'ted.fox@example.com',
      imageUrl:
        'https://images.unsplash.com/photo-1500648767791-00dcc994a43e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    },
    date: '2020-01-07',
    dateFull: 'January 7, 2020',
    stage: 'Completed phone screening',
    href: '#',
  },
]

/* 
email
: 
"Aman@example.com"
enrollments
: 
[]
firstName
: 
"Aman"
id
: 
2
lastName
: 
"Singh"
numberOfCoursesCompleted
: 
0
numberOfCoursesEnrolled
: 
0
registrationDate
: 
"0001-01-01T00:00:00"
role
: 
"User"
*/

export default function Students() {
    const { authUser } : {authUser : any} = useAuth()
    const [students, setStudents] = useState<Array<any>>();

    useEffect(() => {
        getAllStudents()
    }, [])

    const getAllStudents = async () => {
        try{
            const students = await axios.get('https://localhost:7010/Auth', { headers: { "Authorization": `Bearer ${authUser?.token}` } })
            console.log(students);
            setStudents(students?.data)
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
      <h3 className="text-lg font-medium leading-6 text-gray-900">Student List</h3>
    </div>
    <div className="overflow-hidden bg-white shadow sm:rounded-md">
    <ul role="list" className="divide-y divide-gray-200">
      {students?.map((applicant) => (
        <li key={applicant.email}>
          <a href={applicant?.href} className="block hover:bg-gray-50">
            <div className="flex items-center px-4 py-4 sm:px-6">
              <div className="flex min-w-0 flex-1 items-center">
                <div className="min-w-0 flex-1 px-4 md:grid md:grid-cols-2 md:gap-4">
                  <div>
                    <p className="truncate text-sm font-medium text-indigo-600">{applicant.firstName} {applicant.lastName}</p>
                    <p className="mt-2 flex items-center text-sm text-gray-500">
                      <EnvelopeIcon className="mr-1.5 h-5 w-5 flex-shrink-0 text-gray-400" aria-hidden="true" />
                      <span className="truncate">{applicant.email}</span>
                    </p>
                  </div>
                  <div className="hidden md:block">
                    <div>
                      <p className="text-sm text-gray-900">
                        Applied on <time dateTime={applicant.registrationDate}>{applicant.registrationDate}</time>
                      </p>
                      <p className="mt-2 flex items-center text-sm text-gray-500">
                        <CheckCircleIcon className="mr-1.5 h-5 w-5 flex-shrink-0 text-green-400" aria-hidden="true" />
                        <span className="pr-2">Number of Courses</span>
                        {applicant.numberOfCoursesEnrolled}
                      </p>
                    </div>
                  </div>
                </div>
              </div>
              <div>
                <ChevronRightIcon className="h-5 w-5 text-gray-400" aria-hidden="true" />
              </div>
            </div>
          </a>
        </li>
      ))}
    </ul>
  </div>
  </>
  )
}
