import { defineStore } from "pinia"

export const useOverlay = defineStore("overlay", {
  state: () => ({
    isOverlayVisible: false,
  }),
  actions: {},
})
