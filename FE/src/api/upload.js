import axiosIns from "@/plugins/axios"

export async function post(file) {
  const formData = new FormData()

  formData.append("file", file)

  const res = await axiosIns.post("upload", formData, {
    headers: {
      "Content-Type": "multipart/form-data",
    },
  })

  return res.data
}
