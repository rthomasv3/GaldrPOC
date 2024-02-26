<template>
    <div class="container">
        <h1>Welcome to Galdr!</h1>

        <h3>This is a Galdr + C# + Vue 3 app.</h3>

        <div class="row">
            <a href="https://github.com/rthomasv3/GaldrPOC" target="_blank">
                <img src="./assets/wizard-round.svg" class="logo" alt="Galdr logo" />
            </a>
            <a href="https://learn.microsoft.com/en-us/dotnet/csharp/" target="_blank">
                <img src="./assets/csharp.png" class="logo" alt="C# logo" />
            </a>
            <a href="https://vuejs.org/" target="_blank">
                <img src="./assets/vue.svg" class="logo" alt="Vue logo" />
            </a>
        </div>

        <Greet />
    </div>
</template>

<script setup>
    import { onMounted } from "vue";
    import Greet from "./Components/Greet.vue";

    onMounted(() => {
        window.addEventListener(
            "testing",
            (e) => {
                console.log("testing was called");
                console.log(e.detail);
            },
            false,
        );

        //galdrInvoke("testAsync")
        //    .then(a => console.log(a))
        //    .catch(e => console.error(e));

        //galdrInvoke("testSync", { someProp: 'value' })
        //    .then(a => console.log(a))
        //    .catch(e => console.error(e));

        //galdrInvoke("testFailureAsync")
        //    .then(a => console.log(a))
        //    .catch(e => console.error(e));

        //galdrInvoke("testFailureSync")
        //    .then(a => console.log(a))
        //    .catch(e => console.error(e));
    })
</script>
