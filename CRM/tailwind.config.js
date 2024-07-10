/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./src/**/*.{html,js,cshtml}",
        "./Views/**/*.cshtml",
        "./Pages/**/*.cshtml",
        "./node_modules/flowbite/**/*.js"
    ],

    theme: {
        extend: {},
    },
    plugins: [
        require('flowbite/plugin')
    ]
}
