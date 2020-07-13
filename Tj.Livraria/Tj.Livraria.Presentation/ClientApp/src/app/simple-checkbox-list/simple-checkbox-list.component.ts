import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: 'simple-checkbox-list',
  templateUrl: 'simple-checkbox-list.component.html'
})
export class SimpleCheckboxListComponent {
  @Input() itemList: any[] = [];
  private filteredItens: Item[] = [];
  @Output() onChangeCheckedList = new EventEmitter<any>();

  search(event: any) {
    const value = event.target.value;

    if (!value.trim()) {
      this.filteredItens = [];

      return;
    }

    if (this.itemList)
      this.filteredItens = this.itemList.filter(h =>
        this.removerAcentos(h.text.toLowerCase().trim()).includes(this.removerAcentos(value.toLowerCase().trim())));
    else
      console.warn("configuration is missing");
  }

  onSelectItem(itemText: string) {
    const checkedItem: any = this.itemList.filter(i => i.text == itemText)[0];

    checkedItem.isChecked = !checkedItem.isChecked;

    this.onChangeCheckedList.emit(this.itemList.filter(i => i.isChecked));
  }

  removerAcentos(newStringComAcento) {
    var string = newStringComAcento;
    var mapaAcentosHex = {
      a: /[\xE0-\xE6]/g,
      e: /[\xE8-\xEB]/g,
      i: /[\xEC-\xEF]/g,
      o: /[\xF2-\xF6]/g,
      u: /[\xF9-\xFC]/g,
      c: /\xE7/g,
      n: /\xF1/g
    };

    for (var letra in mapaAcentosHex) {
      var expressaoRegular = mapaAcentosHex[letra];
      string = string.replace(expressaoRegular, letra);
    }

    return string;
  }
}

export class Item {
  public cod: number;
  public text: string;
  public isChecked: boolean = false;

  constructor(cod: number, text: string) {
    this.cod = cod;
    this.text = text;
  }
}
