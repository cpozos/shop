var app = new Vue({
    el: '#app',
    data: {
        editing: false,
        loading: false,
        objectIndex: 0,
        productModel: {
            id: 0,
            name: "Product Name",
            description: "Product description",
            price: 1.99
        },
        products: []
    },

    // Live cycle hooks
    mounted() {
        // Using it, it is not necessary 'Get products' button
        this.getProducts();
    },

    methods: {

        getProduct(id) {
            this.loading = true;

            axios.get("/Admin/products/" + id)
                .then(res => {
                    console.log(res);
                    var product = res.data;
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        price: product.price
                    };
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },

        getProducts() {
            this.loading = true;

            axios.get('/Admin/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },

        createProduct() {
            this.loading = true;
            axios.post('/Admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },

        updateProduct() {
            this.loading = true;
            axios.put('/Admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.splice(this.objectIndex, 1, res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.editing = false;
                    this.loading = false;
                });
        },

        editProduct(id, index) {
            this.editing = true;
            this.objectIndex = index;
            this.getProduct(id);
        },

        deleteProduct(id, index) {
            this.loading = true;
            axios.delete('/Admin/products/' + id)
                .then(res => {
                    console.log(res);
                    this.products.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },

        newProduct() {
            this.editing = true;
            this.productModel.id = 0;
        },

        cancel() {
            this.editing = false;
        }
    },

    computed: {
        formatPrice: function () {
            return `$ ${product.price}`
        }
    }
});