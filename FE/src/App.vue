<script setup>
import { useTheme } from "vuetify"
import ScrollToTop from "@core/components/ScrollToTop.vue"
import { useThemeConfig } from "@core/composable/useThemeConfig"
import { hexToRgb } from "@layouts/utils"
import { useSnackbar } from "./stores/snackbar"
import { useOverlay } from "./stores/overlay"
import * as accountAPI from "@/api/account"
import * as tokenAPI from "@/api/token"
import { useUser } from "@/stores/user"

const snackbarStore = useSnackbar()
const overlayStore = useOverlay()
const userStore = useUser()

const {
  syncInitialLoaderTheme,
  syncVuetifyThemeWithTheme: syncConfigThemeWithVuetifyTheme,
  isAppRtl,
  handleSkinChanges,
} = useThemeConfig()

const { global } = useTheme()

// ℹ️ Sync current theme with initial loader theme
syncInitialLoaderTheme()
syncConfigThemeWithVuetifyTheme()
handleSkinChanges()

const refreshToken = async () => {
  overlayStore.isOverlayVisible = true

  const data = {
    token: localStorage.getItem("accessToken"),
    refreshToken: localStorage.getItem("refreshToken"),
  }

  const res = await tokenAPI.refresh(data)

  overlayStore.isOverlayVisible = false

  if (res.success) {
    localStorage.setItem("accessToken", res.data.token)
  }
}

const getUserData = async () => {
  await refreshToken()
  overlayStore.isOverlayVisible = true

  const res = await accountAPI.get()

  overlayStore.isOverlayVisible = false

  if (res.success) {
    userStore.userData = res.data
  }
}

if (!!localStorage.getItem("accessToken")) {
  getUserData()
}
</script>

<template>
  <VLocaleProvider :rtl="isAppRtl">
    <!-- ℹ️ This is required to set the background color of active nav link based on currently active global theme's primary -->
    <VApp
      :style="`--v-global-theme-primary: ${hexToRgb(
        global.current.value.colors.primary
      )}`"
    >
      <RouterView />
      <ScrollToTop />
      <VSnackbar
        v-model="snackbarStore.isSnackbarVisible"
        location="top end"
      >
        {{ snackbarStore.content }}

        <template #actions>
          <VBtn
            color="error"
            @click="snackbarStore.isSnackbarVisible = false"
          >
            Close
          </VBtn>
        </template>
      </VSnackbar>
      <VOverlay
        v-model="overlayStore.isOverlayVisible"
        persistent
        class="align-center justify-center"
      >
        <VProgressCircular
          color="primary"
          indeterminate
        />
      </VOverlay>
    </VApp>
  </VLocaleProvider>
</template>
