import { defineStore } from "pinia"

export const useSnackbar = defineStore('snackbar', {
  state: () => ({
    isSnackbarVisible: false,
    content: "",
  }),
  actions: {
    showSnackbar(content) {
      if(this.isSnackbarVisible)
      {
        this.isSnackbarVisible = false
      }
      this.content = content
      this.isSnackbarVisible = true
      setInterval(() => {
        this.isSnackbarVisible = false
      }, 3000)
    },
  },
})
