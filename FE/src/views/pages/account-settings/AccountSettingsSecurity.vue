<script setup>
import * as accountAPI from "@/api/account"
import { useOverlay } from "@/stores/overlay"
import { useSnackbar } from "@/stores/snackbar"

const overlayStore = useOverlay()

const isCurrentPasswordVisible = ref(false)
const isNewPasswordVisible = ref(false)
const isConfirmPasswordVisible = ref(false)
const currentPassword = ref("")
const newPassword = ref("")
const confirmPassword = ref("")
const refVForm = ref()
const router = useRouter()

const passwordRequirements = [
  "Minimum 4 characters long - the more, the better",
]

const logout = async () => {
  overlayStore.isOverlayVisible = true

  const res = await accountAPI.logout()

  overlayStore.isOverlayVisible = false

  if (res.success) {
    localStorage.removeItem("userData")
    localStorage.removeItem("accessToken")

    router.replace("/login")
  }
}

const changePassword = async () => {
  overlayStore.isOverlayVisible = true

  const data = {
    oldPassword: currentPassword.value,
    newPassword: newPassword.value,
    confirmPassword: confirmPassword.value,
  }

  const res = await accountAPI.changePassword(data)

  overlayStore.isOverlayVisible = false

  if (res.success) {
    logout()
  }
}

const onSubmit = () => {
  refVForm.value?.validate().then(({ valid: isValid }) => {
    if (isValid) changePassword()
  })
}
</script>

<template>
  <VRow>
    <!-- SECTION: Change Password -->
    <VCol cols="12">
      <VCard title="Change Password">
        <VForm
          ref="refVForm"
          @submit.prevent="onSubmit"
        >
          <VCardText class="pt-0">
            <!-- 👉 Current Password -->
            <VRow>
              <VCol
                cols="12"
                md="6"
              >
                <!-- 👉 current password -->
                <AppTextField
                  v-model="currentPassword"
                  :type="isCurrentPasswordVisible ? 'text' : 'password'"
                  :append-inner-icon="
                    isCurrentPasswordVisible ? 'tabler-eye-off' : 'tabler-eye'
                  "
                  label="Current Password"
                  @click:append-inner="
                    isCurrentPasswordVisible = !isCurrentPasswordVisible
                  "
                />
              </VCol>
            </VRow>

            <!-- 👉 New Password -->
            <VRow>
              <VCol
                cols="12"
                md="6"
              >
                <!-- 👉 new password -->
                <AppTextField
                  v-model="newPassword"
                  :type="isNewPasswordVisible ? 'text' : 'password'"
                  :append-inner-icon="
                    isNewPasswordVisible ? 'tabler-eye-off' : 'tabler-eye'
                  "
                  label="New Password"
                  @click:append-inner="
                    isNewPasswordVisible = !isNewPasswordVisible
                  "
                />
              </VCol>

              <VCol
                cols="12"
                md="6"
              >
                <!-- 👉 confirm password -->
                <AppTextField
                  v-model="confirmPassword"
                  :type="isConfirmPasswordVisible ? 'text' : 'password'"
                  :append-inner-icon="
                    isConfirmPasswordVisible ? 'tabler-eye-off' : 'tabler-eye'
                  "
                  label="Confirm New Password"
                  @click:append-inner="
                    isConfirmPasswordVisible = !isConfirmPasswordVisible
                  "
                />
              </VCol>
            </VRow>
          </VCardText>

          <!-- 👉 Password Requirements -->
          <VCardText>
            <h6 class="text-base font-weight-medium mb-3">
              Password Requirements:
            </h6>

            <VList class="card-list">
              <VListItem
                v-for="item in passwordRequirements"
                :key="item"
                :title="item"
                class="text-medium-emphasis"
              >
                <template #prepend>
                  <VIcon
                    size="8"
                    icon="tabler-circle"
                    class="me-3"
                  />
                </template>
              </VListItem>
            </VList>
          </VCardText>

          <!-- 👉 Action Buttons -->
          <VCardText class="d-flex flex-wrap gap-4">
            <VBtn type="submit">
              Save changes
            </VBtn>

            <VBtn
              type="reset"
              color="secondary"
              variant="tonal"
            >
              Reset
            </VBtn>
          </VCardText>
        </VForm>
      </VCard>
    </VCol>
    <!-- !SECTION -->
  </VRow>
</template>

<style lang="scss" scoped>
.card-list {
  --v-card-list-gap: 5px;
}

.server-close-btn {
  inset-inline-end: 0.5rem;
}
</style>
