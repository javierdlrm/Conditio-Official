interface IDictionary<T> {
    add(key: string, value: T): void;
    remove(key: string): void;
    containsKey(key: string): boolean;
    getKeys(): string[];
    getValues(): T[];
}

class Dictionary<T> {

    private keys: string[] = [];
    private values: T[] = [];

    constructor(init: { key: string; value: T; }[]) {
        for (const x of Object.keys(init)) {
            this[init[x].key] = init[x].value;
            this.keys.push(init[x].key);
            this.values.push(init[x].value);
        }
    }

    add(key: string, value: T) {
        this[key] = value;
        this.keys.push(key);
        this.values.push(value);
    }

    remove(key: string) {
        const index = this.keys.indexOf(key, 0);
        this.keys.splice(index, 1);
        this.values.splice(index, 1);

        delete this[key];
    }

    getKeys(): string[] {
        return this.keys;
    }

    getValues(): T[] {
        return this.values;
    }

    containsKey(key: string) {
        if (typeof this[key] === 'undefined') {
            return false;
        }

        return true;
    }

    toLookup(): IDictionary<T> {
        return this;
    }
}
