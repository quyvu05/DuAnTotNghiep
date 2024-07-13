import axiosIns from "@/plugins/axios"

export async function login(data, includeRefreshToken) {
  const res = await axiosIns.post("account/login", data, {
    params: { includeRefreshToken },
  })
  
  return res.data
}

export async function logout() {
  const res = await axiosIns.post("account/logout")

  return res.data
}

export async function get() {
  const res = await axiosIns.get("account")
  
  return res.data
}

export async function put(data) {
  const res = await axiosIns.put("account", data)
  
  return res.data
}

export async function changePassword(data) {
  const res = await axiosIns.put("account/change-password", data)
  
  return res.data
}
