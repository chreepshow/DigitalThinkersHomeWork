import { Home } from './components/Home'
import { DriverList } from './components/DriverList'

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: '/drivers',
    element: <DriverList />,
  },
]

export default AppRoutes
