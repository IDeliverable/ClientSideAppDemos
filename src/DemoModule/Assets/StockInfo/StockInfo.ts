/// <reference path="../../../../../node_modules/@types/jquery/index.d.ts" />

import * as template from "./StockInfo.handlebars";
import "./StockInfo.scss";

function init(elementId: string, parameters: StockInfoParameters): void
{
    $.ajax(`${parameters.apiUrl}/${parameters.productId}`).done((response) =>
    {
        var markup = template({
            productId: parameters.productId,
            stockLocations: response
        });

        $(() =>
        {
            $(`#${elementId}`).replaceWith(markup);
        });
    });
}

interface StockInfoParameters
{
    apiUrl: string,
    productId: number;
}

(<any>window).initStockInfo = init;