import axiosIns from "@/plugins/axios"

export async function refresh(data) {
  const res = await axiosIns.post("token/refresh", data)

  return res.data
}
