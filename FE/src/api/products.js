import axiosIns from "@/plugins/axios"

export async function listProduct(data) {
  const res = await axiosIns.post("products/list-product", data)

  return res.data
}
