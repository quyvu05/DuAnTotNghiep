<script setup>
const props = defineProps({
  product: {
    type: Object,
    required: true,
  },
})
</script>

<template>
  <VCard>
    <VImg
      :src="product.mediaUrl"
      style="height: 300px;"
    />
    <VCardTitle>{{ product.name }}</VCardTitle>
    <VCardSubtitle>{{ product.price }} $</VCardSubtitle>
    <VCardActions class="d-flex justify-space-between">
      <VBtn @click="() => {}">
        Add to cart
      </VBtn>
      <IconBtn
        size="small"
        @click="() => {}"
      >
        <VIcon icon="tabler-heart" />
      </IconBtn>
    </VCardActions>
  </VCard>
</template>
