Vue.component('product-manager', {
    template: `<div>
                <div v-if="!editing">
                    <button class="button" @click="newProduct">Add New product</button>

                    <table class="table">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Description</th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(product, index) in products">
                                <td>{{product.id}}</td>
                                <td>{{product.name}}</td>
                                <td>{{product.price}}</td>
                                <td><a @click="editProduct(product.id, index)">Edit</a></td>
                                <td><a @click="deleteProduct(product.id, index)">Delete</a></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div v-else>
                    <div class="field">
                        <label class="label">Product Name</label>
                        <div class="control">
                            <input class="input" v-model="productModel.name" />
                        </div>
                    </div>

                    <div class="field">
                        <label class="label">Product Description</label>
                        <div class="control">
                            <input class="input" v-model="productModel.description" />
                        </div>
                    </div>

                    <div class="field">
                        <label class="label">Price</label>
                        <div class="control">
                            <input class="input" type="number" v-model.number="productModel.price" />
                        </div>
                    </div>

                    <button class="button is-success" @click="createProduct" v-if="!productModel.id">Create proudct</button>
                    <button class="button is-warning" @click="updateProduct" v-else>Update proudct</button>
                    <button class="button" @click="cancel">Cancel</button>

                </div>
            </div>`,

    data() {
        return {
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
        };
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