<template>
    <form class="row" @submit.prevent="greet">
        <input id="greet-input" v-model="name" placeholder="Enter a name..." autocomplete="off" />
        <button type="submit">Greet</button>
    </form>

    <p>{{ greetMsg }}</p>
</template>

<script setup>
import { ref } from "vue";

const greetMsg = ref("");
const name = ref("");

async function greet() {
    greetMsg.value = await galdrInvoke("greet", { name: name.value });
}
</script>
