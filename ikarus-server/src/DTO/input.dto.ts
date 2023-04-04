export interface Input {
  type: string; // "button" | "joystick"
  eventType: string; // "down", "move", "up"
  data: null | any; //null | {name: "movement", direction :{X:0.5, y:-0.2}} | {name:'jump'}
}
