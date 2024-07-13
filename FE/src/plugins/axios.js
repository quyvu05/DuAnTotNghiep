import axios from "axios"
import router from "@/router"
import { useOverlay } from "@/stores/overlay"
import { useSnackbar } from "@/stores/snackbar"

const axiosIns = axios.create({
  // You can add your headers here
  // ================================
  baseURL: import.meta.env.VITE_BACK_END_API,
  timeout: 1000,
})

// ℹ️ Add request interceptor to send the authorization header on each subsequent request after login
axiosIns.interceptors.request.use(config => {
  // Retrieve token from localStorage
  const token = localStorage.getItem("accessToken")

  // If token is found
  if (token) {
    // Get request headers and if headers is undefined assign blank object
    config.headers = config.headers || {}

    // Set authorization header
    // ℹ️ JSON.parse will convert token to string
    config.headers.Authorization = token ? `Bearer ${token}` : ""
  }

  // Return modified config
  return config
})

// ℹ️ Add response interceptor to handle 401 response
axiosIns.interceptors.response.use(
  response => {
    const snackbarStore = useSnackbar()

    if (!response.data.success) {
      snackbarStore.showSnackbar(response.data.message)
    }

    return response
  },
  error => {
    const overlayStore = useOverlay()

    overlayStore.isOverlayVisible = false

    // Handle error
    if (error.response.status === 401) {
      // Remove "accessToken" from localStorage
      localStorage.removeItem("accessToken")

      // If 401 response returned from api
      router.push("/login")
    } else {
      return Promise.reject(error)
    }
  },
)
export default axiosIns
