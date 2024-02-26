<template>
    <div class="container">
        <h1>This is a Galdur + C# + Vue 3 app.</h1>
    </div>
</template>

<script setup>
    import { onMounted } from 'vue'

    onMounted(() => {
        window.addEventListener(
            "testing",
            (e) => {
                console.log("testing was called");
                console.log(e.detail);
            },
            false,
        );

        galdurInvoke("testAsync")
            .then(a => console.log(a))
            .catch(e => console.error(e));

        galdurInvoke("testSync", { someProp: 'value' })
            .then(a => console.log(a))
            .catch(e => console.error(e));

        galdurInvoke("testFailureAsync")
            .then(a => console.log(a))
            .catch(e => console.error(e));

        galdurInvoke("testFailureSync")
            .then(a => console.log(a))
            .catch(e => console.error(e));
    })
</script>
