﻿<template>
    <form class="row" @submit.prevent="greet">
        <input id="greet-input" v-model="name" placeholder="Enter a name..." autocomplete="off" />
        <button type="submit">Greet</button>
    </form>

    <p>{{ greetMsg }}</p>

    <form class="row" @submit.prevent="browse">
        <input id="greet-input" v-model="file" placeholder="Select a file..." autocomplete="off" readonly />
        <button type="submit">Browse</button>
    </form>
</template>

<script setup>
import { ref } from "vue";

const greetMsg = ref("");
const name = ref("");
const file = ref("");

async function greet() {
    greetMsg.value = await galdrInvoke("greet", { name: name.value });
}

async function browse() {
    file.value = await galdrInvoke("browseFiles");
}
</script>
