<script setup>
import * as accountAPI from "@/api/account"
import * as uploadAPI from "@/api/upload"
import avatar1 from "@images/avatars/avatar-1.png"
import { useOverlay } from "@/stores/overlay"
import { useSnackbar } from "@/stores/snackbar"
import { useUser } from "@/stores/user"

const userStore = useUser()
const accountDataLocal = ref({ ...userStore.userData })

const overlayStore = useOverlay()
const snackbarStore = useSnackbar()
const refVForm = ref()

const updateUser = async () => {
  overlayStore.isOverlayVisible = true

  const data = {
    fullName: accountDataLocal.value.fullName,
    mediaId: accountDataLocal.value.mediaId,
  }

  const res = await accountAPI.put(data)

  overlayStore.isOverlayVisible = false

  if (res.success) {
    userStore.userData = accountDataLocal.value
  }
}

const onSubmit = () => {
  refVForm.value?.validate().then(({ valid: isValid }) => {
    if (isValid) updateUser()
  })
}

const refInputEl = ref()

const resetForm = () => {
  accountDataLocal.value = { ...userStore.userData }
}

const changeAvatar = async file => {
  const { files } = file.target

  if (files[0].size / (1024 * 1024) > 1) {
    snackbarStore.showSnackbar("Choose files smaller than 1MB")
    
    return
  }

  if (files && files.length) {
    const res = await uploadAPI.post(files[0])

    if (res.success) {
      accountDataLocal.value.avatar = res.data.url
      accountDataLocal.value.mediaId = res.data.id
    } 
  }
}

const resetAvatar = () => {
  accountDataLocal.value.avatar = userStore.userData.avatar
}
</script>

<template>
  <VRow>
    <VCol cols="12">
      <VCard title="Profile Details">
        <VCardText class="d-flex">
          <!-- 👉 Avatar -->
          <VAvatar
            rounded
            size="100"
            class="me-6"
            :image="accountDataLocal.avatar ?? avatar1"
          />

          <!-- 👉 Upload Photo -->
          <form class="d-flex flex-column justify-center gap-4">
            <div class="d-flex flex-wrap gap-2">
              <VBtn
                color="primary"
                @click="refInputEl?.click()"
              >
                <VIcon
                  icon="tabler-cloud-upload"
                  class="d-sm-none"
                />
                <span class="d-none d-sm-block">Upload new photo</span>
              </VBtn>

              <input
                ref="refInputEl"
                type="file"
                name="file"
                accept=".jpeg,.png,.jpg,GIF"
                hidden
                @input="changeAvatar"
              >

              <VBtn
                type="reset"
                color="secondary"
                variant="tonal"
                @click="resetAvatar"
              >
                <span class="d-none d-sm-block">Reset</span>
                <VIcon
                  icon="tabler-refresh"
                  class="d-sm-none"
                />
              </VBtn>
            </div>

            <p class="text-body-1 mb-0">
              Allowed JPG, GIF or PNG. Max size of 800K
            </p>
          </form>
        </VCardText>

        <VDivider />

        <VCardText class="pt-2">
          <!-- 👉 Form -->
          <VForm
            ref="refVForm"
            class="mt-6"
            @submit.prevent="onSubmit"
          >
            <VRow>
              <!-- 👉 Full Name -->
              <VCol
                md="6"
                cols="12"
              >
                <AppTextField
                  v-model="accountDataLocal.fullName"
                  label="Full Name"
                />
              </VCol>

              <!-- 👉 Form Actions -->
              <VCol
                cols="12"
                class="d-flex flex-wrap gap-4"
              >
                <VBtn type="submit">
                  Save changes
                </VBtn>

                <VBtn
                  color="secondary"
                  variant="tonal"
                  type="reset"
                  @click.prevent="resetForm"
                >
                  Reset
                </VBtn>
              </VCol>
            </VRow>
          </VForm>
        </VCardText>
      </VCard>
    </VCol>
  </VRow>
</template>
