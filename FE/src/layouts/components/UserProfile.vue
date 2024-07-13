<script setup>
import avatar1 from "@images/avatars/avatar-1.png"
import { useSnackbar } from "@/stores/snackbar"
import { useOverlay } from "@/stores/overlay"
import * as accountAPI from "@/api/account"
import { useUser } from "@/stores/user"

const userStore = useUser()
const isLogin = !!localStorage.getItem("accessToken")
const overlayStore = useOverlay()
const router = useRouter()

const logout = async () => {
  overlayStore.isOverlayVisible = true

  const res = await accountAPI.logout()

  overlayStore.isOverlayVisible = false

  if (res.success) {
    localStorage.removeItem("accessToken")
    userStore.userData = {}

    router.replace("/login")
  }
}
</script>

<template>
  <VBadge
    dot
    location="bottom right"
    offset-x="3"
    offset-y="3"
    bordered
    color="success"
  >
    <VAvatar
      class="cursor-pointer"
      color="primary"
      variant="tonal"
    >
      <VImg :src="userStore.userData.avatar??avatar1" />

      <!-- SECTION Menu -->
      <VMenu
        activator="parent"
        width="230"
        location="bottom end"
        offset="14px"
      >
        <VList>
          <!-- 👉 User Avatar & Name -->
          <VListItem>
            <template #prepend>
              <VListItemAction start>
                <VBadge
                  dot
                  location="bottom right"
                  offset-x="3"
                  offset-y="3"
                  color="success"
                >
                  <VAvatar
                    color="primary"
                    variant="tonal"
                  >
                    <VImg :src="userStore.userData.avatar??avatar1" />
                  </VAvatar>
                </VBadge>
              </VListItemAction>
            </template>

            <VListItemTitle class="font-weight-semibold">
              {{ userStore.userData.fullName }}
            </VListItemTitle>
            <VListItemSubtitle>{{ userStore.userData.email }}</VListItemSubtitle>
          </VListItem>

          <VDivider class="my-2" />

          <VListItem to="/account-settings/account">
            <template #prepend>
              <VIcon
                class="me-2"
                icon="tabler-users"
                size="22"
              />
            </template>

            <VListItemTitle>Account</VListItemTitle>
          </VListItem>

          <VListItem to="/account-settings/security">
            <template #prepend>
              <VIcon
                class="me-2"
                icon="tabler-lock"
                size="22"
              />
            </template>
          
            <VListItemTitle>Security</VListItemTitle>
          </VListItem>

          <!-- Divider -->
          <VDivider class="my-2" />

          <!-- 👉 Logout -->
          <VListItem @click="logout">
            <template #prepend>
              <VIcon
                class="me-2"
                icon="tabler-logout"
                size="22"
              />
            </template>

            <VListItemTitle>{{ isLogin?'Logout':'Login' }}</VListItemTitle>
          </VListItem>
        </VList>
      </VMenu>
      <!-- !SECTION -->
    </VAvatar>
  </VBadge>
</template>
