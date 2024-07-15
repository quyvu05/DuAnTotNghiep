<script setup>
import * as productsAPI from "@/api/products"
import { useOverlay } from "@/stores/overlay"
import ProductCard from "@/views/pages/list-product/ProductCard.vue"

const overlayStore = useOverlay()
const listProduct = ref([])

const options = ref({
  pagination: {
    total: 0,
    current: 1,
    pageSize: 100,
  },
  search: {},
  sort: {},
})

const getAllProduct = async () => {
  overlayStore.isOverlayVisible = true

  const res = await productsAPI.listProduct(options.value)

  overlayStore.isOverlayVisible = false

  if (res.success) {
    listProduct.value = res.data.list
  }
}

getAllProduct()
</script>

<template>
  <div>
    <VRow>
      <VCol
        v-for="product in listProduct"
        :key="product.id"
        xxl="1"
        xl="2"
        lg="3"
        md="3"
        sm="4"
      >
        <ProductCard :product="product" />
      </VCol>
    </VRow>
  </div>
</template>
