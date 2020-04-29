
export interface Alert {
    type: string;
    message: string;
}

export enum ALERT {
    SUCCESS, INFO, WARNING, DANGER,
    PRIMARY, LIGHT, DARK
}

export const ALERTS: { [index: string]: Alert; } = {
    SUCCESS: { type: 'success', message: 'This is an success alert' },
    INFO: { type: 'success', message: 'This is an success alert' },
    WARNING: { type: 'warning', message: 'This is a warning alert' },
    DANGER: { type: 'danger', message: 'This is a danger alert' },
    PRIMARY: { type: 'primary', message: 'This is a primary alert' },
    LIGHT: { type: 'light', message: 'This is a light alert' },
    DARK: { type: 'dark', message: 'This is a dark alert' }
};
