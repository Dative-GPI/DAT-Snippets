@Inject(PROVIDER)
container!: DependencyContainer;

fetching = true;
$1: $0;

get $1Service(): I$1Service {
    return this.container.resolve<I$1Service>(SERVICES.$1SERVICE)
}

mounted() {
    this.fetch();
}

async fetch() {
    this.fetching = true;

    try {
        this.$1 = await $1Service.get($3);
    } finally {
        this.fetching = false;
    }
}